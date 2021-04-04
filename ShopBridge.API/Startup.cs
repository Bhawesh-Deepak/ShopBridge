using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopBridge.Core.Entity.ShopBridgeContext;
using ShopBridge.Infrastructure.Repository.RepositoryExtension;
using ShopBridge.Infrastructure.Service.ServiceExtension;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ShopBridge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRepositoryService();
            services.AddServicesService();
            services.AddSwaggerGen(option =>
            {

                var filePath = System.IO.Path.Combine(AppContext.BaseDirectory, "ShopBridge.API.xml");
                option.IncludeXmlComments(filePath);

            });
            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "ShowBridgeAPI");
                option.DocExpansion(DocExpansion.List);
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
