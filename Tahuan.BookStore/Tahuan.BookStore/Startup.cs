using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahuan.BookStore.Data;
using Tahuan.BookStore.Repository;

namespace Tahuan.BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server =.; Database = BookStore; Integrated Security = True;"));
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //.AddViewOptions(option =>
            //{
            //      option.HtmlHelperOptions.ClientValidationEnabled = false;
            //});
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<LanguageRepository, LanguageRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //add custom middleware - Taylor

            //app.Use(async(context, next) =>
            //{
            //    await context.Response.WriteAsync("1st middleware - ");
            //    await next();
            //    await context.Response.WriteAsync("back to 1st middleware - ");

            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("2nd middleware - ");
            //});

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); //URL/home/index
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!" + env.EnvironmentName);
                //});
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/taylor", async context =>
                {
                    await context.Response.WriteAsync("Hello Taylor!");
                });
            });
        }
    }
}
