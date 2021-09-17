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
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
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
                    endpoints.MapDefaultControllerRoute();
                    // endpoints.MapControllerRoute(
                    //     name: "Default",
                    //     pattern: "{controller=Home}/{action=Index}/{id?}/{name?}"
                    
                });
            }
        }
    }

