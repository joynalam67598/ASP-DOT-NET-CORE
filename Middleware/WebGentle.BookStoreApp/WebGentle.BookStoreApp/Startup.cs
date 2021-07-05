using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use( async (constext, next) =>
            {
                await constext.Response.WriteAsync("1st Middlewre \n"); // 1st
                await next();
                await constext.Response.WriteAsync("1st Middlewre Response \n"); // 5th
            });

            app.Use(async (constext, next) =>
            {
                await constext.Response.WriteAsync("2nd Middlewre \n"); // 2nd
                await next();
                await constext.Response.WriteAsync("2nd Middlewre Response \n"); // 4th
            });

            app.Use(async (constext, next) =>
            {
                await constext.Response.WriteAsync("3nd Middlewre \n"); //3rd
                // Next use na korle nicher code golu ar run hobe na.
                await next();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Handle perticular Get Request Only
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Handle perticular Get Request Only \n");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                // Handle All type of request
                endpoints.Map("/map", async context =>
                {
                    await context.Response.WriteAsync("Handle All type of Request \n");
                });
            });
        }
    }
}
