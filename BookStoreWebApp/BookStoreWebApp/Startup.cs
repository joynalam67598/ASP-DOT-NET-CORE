using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Controllers;
using BookStoreWebApp.Data;
using BookStoreWebApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=.\\SQLExpress; Database=BookStore; Integrated Security=True;"));
            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
        }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                
                app.UseStaticFiles();

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    // endpoints.MapDefaultControllerRoute();
                    // endpoints.MapControllerRoute(
                    //     name: "Default",
                    //     pattern: "{controller=Home}/{action=Index}/{id?}/{name?}"
                    //     // default value diye rakle error hoy na
                    //
                    // );
                    // endpoints.MapControllerRoute(
                    //     name: "AboutUs",
                    //     pattern: "about-us/{id?}",
                    //     defaults: new {controllers= "Home", action="AboutUs"}
                    //
                    // ); // this conventional Routing
                });
            }
        }
    }

