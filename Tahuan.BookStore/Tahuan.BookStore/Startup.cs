using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahuan.BookStore.Data;
using Tahuan.BookStore.Models;
using Tahuan.BookStore.Repository;

namespace Tahuan.BookStore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Use this method to add services to the container. This method gets called by the runtime. 
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // IServiceCollection 用于注册dependancy 的容器 ： Dependancy Injection 
        // where services are registered
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookStoreContext>();

            services.Configure<IdentityOptions>( options => 
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false; 
            });

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //.AddViewOptions(option =>
            //{
            //      option.HtmlHelperOptions.ClientValidationEnabled = false;
            //});
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.Configure<NewBookAlertConfig>(_configuration.GetSection("NewBookAlert"));            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //add custom middleware - Taylor
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

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

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); //URL/home/index
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!" + env.EnvironmentName);
                //});

                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name: "AboutUs",
                //    pattern: "about-us",
                //    defaults: new { controller = "Home", action = "AboutUs"});
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/taylor", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Taylor!");
            //    });
            //});
        }
    }
}
