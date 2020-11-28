using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication2;

[assembly: PreApplicationStartMethod(typeof(MvcApplication), "InitModule")]

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void InitModule()
        {
            RegisterModule(typeof(ServiceScopeModule));
        }

        protected void Application_Start()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceScopeModule.SetServiceProvider(services.BuildServiceProvider());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var resolver = new ServiceProviderDependencyResolver();
            DependencyResolver.SetResolver(resolver);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersAsServices(
                typeof(MvcApplication).Assembly.GetExportedTypes()
                   .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                   .Where(t => typeof(IController).IsAssignableFrom(t) || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            );

            // ここから下に、DIしたいインターフェイスと具象クラスを記述
            //services.AddTransient<Models.ISomeClient, Models.SomeClient>();
            services.AddScoped<Models.ISomeClient, Models.SomeClient>();
            //services.AddSingleton<Models.ISomeClient, Models.SomeClient>();

            services.AddScoped<Services.ISomeService, Services.SomeService>();

            // -------------------------------------------------------------------------------------------------->
            // ISomeClient が AddTransient で注入されれば、次のコードで別の SomeClient インスタンスが生成される。
            //services.AddScoped<Services.IScopedSomeService1, Services.SomeService>();
            //services.AddScoped<Services.IScopedSomeService2, Services.SomeService>();

            // ISomeClient が AddScoped で注入されても、次のコードで明示的に SomeClient インスタンスが生成することができる。
            services.AddScoped<Services.IScopedSomeService1>(provider => new Services.SomeService(new Models.SomeClient()));
            services.AddScoped<Services.IScopedSomeService2>(provider => new Services.SomeService(new Models.SomeClient()));
            // <--------------------------------------------------------------------------------------------------
        }
    }

    internal class ServiceScopeModule : IHttpModule
    {
        private static ServiceProvider _serviceProvider;

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            context.Items[typeof(IServiceScope)] = _serviceProvider.CreateScope();
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            if (context.Items[typeof(IServiceScope)] is IServiceScope scope)
            {
                scope.Dispose();
            }
        }

        public static void SetServiceProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }

    internal class ServiceProviderDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (HttpContext.Current?.Items[typeof(IServiceScope)] is IServiceScope scope)
            {
                return scope.ServiceProvider.GetService(serviceType);
            }

            throw new InvalidOperationException("IServiceScope not provided");
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (HttpContext.Current?.Items[typeof(IServiceScope)] is IServiceScope scope)
            {
                return scope.ServiceProvider.GetServices(serviceType);
            }

            throw new InvalidOperationException("IServiceScope not provided");
        }
    }

    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }

}
