using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tavisca.CAPI.AccessKey.Web.Middleware.Extensions;
using Tavisca.Common.Plugins.StructureMap;
using Tavisca.Platform.Common.Containers;
using Tavisca.Platform.Common.Core.ServiceLocator;
using Tavisca.CAPI.AccessKey.Web.Middleware.Extenstions;
using capi_accesskey.Middlewares;
using capi_accesskey.Middlewares.Extensions;

namespace Tavisca.CAPI.AccessKey.Web
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
            services.AddHealthChecks()
            .AddCheck<HealthCheckMiddleware>("example_health_check");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var serviceLocator = new NetCoreServiceLocator(new ContainerFactory(services), GetModules());
            return serviceLocator;
        }
        private IModule[] GetModules()
        {
            return new IModule[]
            {
                    new Module()
            };
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseRewindContextStreamMiddleware();
            app.UseCustomExceptionHandler();
            app.UseContextInjector();
            app.UseProfiling();
            app.UseLogging();
            app.UseMvc();
        }
    }
}
