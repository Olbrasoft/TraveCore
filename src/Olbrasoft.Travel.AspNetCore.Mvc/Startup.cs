using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Mapping.AutoMapper;
using Olbrasoft.Data.Querying;
using Olbrasoft.Data.Querying.Factories;
using Olbrasoft.Dependence;
using Olbrasoft.Dependence.Inversion.Of.Control.Containers.Castle;
using Olbrasoft.Travel.Business;
using Olbrasoft.Travel.Business.Services;
using Olbrasoft.Travel.Data.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Transfer;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;

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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            ConfigureLocalization(services);

            var container = new WindsorContainer();

            ConfigureContexts(container);

            #region Querying ------------------------------------------------------------------------------------------

            container.Register(Component.For<IResolver>().ImplementedBy<ObjectResolverWithDependentCastle>());

            ConfigureQuerying(container);

            ConfigureQueries(container);

            ConfigureQueryHandlers(container);

            #endregion Querying ------------------------------------------------------------------------------------------

            #region Mapping --------------------------------------------------------------------------------------------

            services.AddAutoMapper(typeof(Data.Mapping.MapperConfigurationProvider).Assembly);

            //container.Register(Component.For<AutoMapper.IConfigurationProvider>().ImplementedBy<Data.Mapping.MapperConfigurationProvider>().LifestyleSingleton());

            container.Register(Component.For<IProjection>().ImplementedBy<Projector>().LifestyleSingleton());

            #endregion Mapping --------------------------------------------------------------------------------------------

            container.Register(
                Component.For<IAccommodationItemPhotoMerge>().ImplementedBy<RealEstateItemPhotoMerge>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            ConfigureBusiness(container);

            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        private static void ConfigureLocalization(IServiceCollection services)
        {
            // Add the localization services to the services container
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // Add support for finding localized views, based on file name suffix, e.g. Index.fr.cshtml
                .AddViewLocalization()
                // Add support for localizing strings in data annotations (e.g. validation messages) via the
                // IStringLocalizer abstractions.
                .AddDataAnnotationsLocalization();
        }

        private static void ConfigureQueries(IWindsorContainer container)
        {
            var classes = Classes.FromAssemblyNamed("Olbrasoft.Travel.Data");

            container.Register(classes
                .Where(type => type.Namespace != null && type.Namespace.Contains("Queries"))
                .WithServiceSelf());
        }

        private static void ConfigureQueryHandlers(IWindsorContainer container)
        {
            var classes = Classes.FromAssemblyNamed(typeof(TravelQueryHandler<,,>).Assembly.GetName().Name);

            container.Register(classes
                .Where(ns => ns.Namespace != null && ns.Namespace.Contains(nameof(Data.EntityFrameworkCore.QueryHandlers)))
                .WithServiceFirstInterface()
                .LifestyleCustom<MsScopedLifestyleManager>());
        }

        private static void ConfigureBusiness(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAccommodations>().ImplementedBy<PropertyService>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(
                Component.For<IRegions>().ImplementedBy<RegionService>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(
                Component.For<ITravel>().ImplementedBy<TravelFacade>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );
        }

        private static void ConfigureContexts(IWindsorContainer container)
        {
            container.Register(
                Component.For<TravelDbContext>().ImplementedBy<TravelDbContext>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );
        }

        private static void ConfigureQuerying(IWindsorContainer container)
        {
            container.Register(Component.For<IQueryFactory>().ImplementedBy<QueryFactory>().LifestyleSingleton());

            container.Register(Component.For(typeof(QueryExecutor<,>)).ImplementedBy(typeof(QueryExecutor<,>))
                .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(
                Component.For<IQueryExecutorFactory>().ImplementedBy<QueryExecutorFactory>().LifestyleSingleton());

            container.Register(Component.For<IQueryDispatcher>().ImplementedBy<QueryDispatcher>().LifestyleSingleton());
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