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
using Olbrasoft.Data.Query;
using Olbrasoft.Dependence;
using Olbrasoft.Dependence.Inversion.Of.Control.Containers.Castle;
using Olbrasoft.Travel.Business;
using Olbrasoft.Travel.Business.Facade;
using Olbrasoft.Travel.Data.Entity.Framework;
using Olbrasoft.Travel.Data.Transfer.Object;
using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

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
                // Add support for finding localized views, based on file name suffix, e.g. Index.fr.cshtml
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                // Add support for localizing strings in data annotations (e.g. validation messages) via the
                // IStringLocalizer abstractions.
                .AddDataAnnotationsLocalization();

          
            // Configure supported cultures and localization options
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("cs"),
                    new CultureInfo("ar-YE")
                };

                // State what the default culture for your application is. This will be used if no specific culture
                // can be determined for a given request.
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");

                // You must explicitly state which cultures your application supports.
                // These are the cultures the app supports for formatting numbers, dates, etc.
                options.SupportedCultures = supportedCultures;

                // These are the cultures the app supports for UI strings, i.e. we have localized resources for.
                options.SupportedUICultures = supportedCultures;

                // You can change which providers are configured to determine the culture for requests, or even add a custom
                // provider with your own logic. The providers will be asked in order to provide a culture for each request,
                // and the first to provide a non-null result that is in the configured supported cultures list will be used.
                // By default, the following built-in providers are configured:
                // - QueryStringRequestCultureProvider, sets culture via "culture" and "ui-culture" query string values, useful for testing
                // - CookieRequestCultureProvider, sets culture via "ASPNET_CULTURE" cookie
                // - AcceptLanguageHeaderRequestCultureProvider, sets culture via the "Accept-Language" request header
                //options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
                //{
                //  // My custom request culture logic
                //  return new ProviderCultureResult("en");
                //}));
            });

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
                .Where(type => type.Namespace != null && type.Namespace.EndsWith("Query"))
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
                Component.For<IAccommodations>().ImplementedBy<AccommodationsFacade>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(
            Component.For<IRegions>().ImplementedBy<RegionsFacade>()
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

            
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}