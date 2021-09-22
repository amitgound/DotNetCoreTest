using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
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
           // services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton<IEmployeeRepository, MocEmployeeRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 1
                }) ;

            }
            else
            { 
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            //FileServerOptions newfilerserverOption = new FileServerOptions();
            //newfilerserverOption.DefaultFilesOptions.DefaultFileNames.Clear();
            //newfilerserverOption.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
          
            //app.UseFileServer(newfilerserverOption);
            //app.UseRouting();

            app.UseAuthorization();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"));

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from first middleware");
            //});

            //app.Run(async (context) =>
            
            //{
            //    throw new Exception("exception from Run");
            //    await context.Response.WriteAsync("Hello from first middleware");
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
                
            //});

            
        }
    }
}
