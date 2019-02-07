using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Mapping.AutoMapper;
using Olbrasoft.Dependence;
using Olbrasoft.Dependence.Inversion.Of.Control.Containers.Castle;
using Olbrasoft.Travel.Business;
using Olbrasoft.Travel.Data.Entity.Framework;
using Olbrasoft.Travel.Data.Transfer.Object;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Business.Services;

namespace Olbrasoft.Travel.AspNetCore.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add the localization services to the services container
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // Add support for finding localized views, based on file name suffix, e.g. Index.fr.cshtml
                .AddViewLocalization()
                // Add support for localizing strings in data annotations (e.g. validation messages) via the
                // IStringLocalizer abstractions.
                .AddDataAnnotationsLocalization();
 
            
            //services.AddScoped<IIdentityContext, IdentityDatabaseContext>();

            var container = new WindsorContainer();

            container.Register(
                Component.For<IIdentityContext>().ImplementedBy<IdentityDatabaseContext>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

           
            container.Register(Component.For<IGlobalizationContext>().ImplementedBy<GlobalizationDatabaseContext>()
                .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(Component.For<IPropertyContext>().ImplementedBy<PropertyDatabaseContext>()
                .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(Component.For<IGeographyContext>().ImplementedBy<GeographyDatabaseContext>()
                .LifestyleCustom<MsScopedLifestyleManager>()
            );

            var classes = Classes.FromAssemblyNamed("Olbrasoft.Travel.Data");

            container.Register(classes
                .Where(type => type.Namespace != null && type.Namespace.EndsWith("Queries"))
                .WithServiceSelf());

            container.Register(Component.For<AutoMapper.IConfigurationProvider>().ImplementedBy<Data.Mapping.Configuration>().LifestyleSingleton());
            container.Register(Component.For<IProjection>().ImplementedBy<Projector>().LifestyleSingleton());

            classes = Classes.FromAssemblyNamed("Olbrasoft.Travel.Data.Entity.Framework");

            container.Register(classes
                .Where(ns => ns.Namespace != null && ns.Namespace.EndsWith("Query.Handler"))
                .WithServiceFirstInterface()
                .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Component.For<IResolver>().ImplementedBy<ObjectResolverWithDependentCastle>());

            container.Register(Component.For<IProvider>().ImplementedBy<ProviderWithWrapperAndDependentResolver>().LifestyleSingleton());

            container.Register(Component
                .For(typeof(ProviderWithWrapperAndDependentResolver.WrapperWithDependentHandler<,>))
                .ImplementedBy(typeof(ProviderWithWrapperAndDependentResolver.WrapperWithDependentHandler<,>))
                .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(
                Component.For<IAccommodationItemPhotoMerge>().ImplementedBy<AccommodationItemPhotoMerge>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(
                Component.For<IAccommodations>().ImplementedBy<AccommodationService>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(
            Component.For<IRegions>().ImplementedBy<RegionService>()
                .LifestyleCustom<MsScopedLifestyleManager>()
                );

            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("cs"),
            };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            var requestProvider = new RouteDataRequestCultureProvider();
            localizationOptions.RequestCultureProviders.Insert(0, requestProvider);

            app.UseRouter(routes =>
            {
                routes.MapMiddlewareRoute("{culture=en-US}/{*mvcRoute}", subApp =>
                {
                    subApp.UseRequestLocalization(localizationOptions);

                    subApp.UseMvc(mvcRoutes =>
                    {
                        mvcRoutes.MapRoute(
                            name: "default",
                            template: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");
                    });
                });
            });


        }
    }


   
}