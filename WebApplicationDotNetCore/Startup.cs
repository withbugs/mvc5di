using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplicationDotNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // ここから下に、DIしたいインターフェイスと具象クラスを記述
            services.AddTransient<Models.ISomeClient, Models.SomeClient>();
            //services.AddScoped<Models.ISomeClient, Models.SomeClient>();
            //services.AddSingleton<Models.ISomeClient, Models.SomeClient>();

            services.AddScoped<Services.ISomeService, Services.SomeService>();

            // -------------------------------------------------------------------------------------------------->
            // ISomeClient が AddTransient で注入されれば、次のコードで別の SomeClient インスタンスが生成される。
            services.AddScoped<Services.IScopedSomeService1, Services.SomeService>();
            services.AddScoped<Services.IScopedSomeService2, Services.SomeService>();

            // ISomeClient が AddScoped で注入されても、次のコードで明示的に SomeClient インスタンスが生成することができる。
            //services.AddScoped<Services.IScopedSomeService1>(provider => new Services.SomeService(new Models.SomeClient()));
            //services.AddScoped<Services.IScopedSomeService2>(provider => new Services.SomeService(new Models.SomeClient()));
            // <--------------------------------------------------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
