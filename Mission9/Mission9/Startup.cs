using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9.Models;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Mission9
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public IConfiguration Configuration { get; set; }
        
        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //~~~add this so that the MVC will be connected
            services.AddControllersWithViews();

            //~~~add connection to the databse
            services.AddDbContext<WaterProjectContext>(options =>
            {
                options.UseSqlite(Configuration["Data Source = Bookstore.sqlite"]);
            });
            services.AddScoped<IBookStore, EFBookStoreRepo>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //~~~corresponds with wwwrooot
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //~~~the default endpoint with go to the index page
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
