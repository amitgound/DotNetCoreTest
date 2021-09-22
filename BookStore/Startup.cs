using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookStore
{
    public class Startup
    {
        private RequestDelegate testa;
        private RequestDelegate testb;
        private Func<HttpContext, Func<Task>, Task> testc;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            testa = new RequestDelegate(test);
            testc = new Func<HttpContext, Func<Task>,Task>(testD);

            //app.Use(testa.Invoke(context=> { new HttpContext}));

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Test from Run");
            });
            app.Run(testa);
            app.Use(testc);

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

            app.UseCors(options => options.WithOrigins("*").WithHeaders("*").WithMethods("*"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public async Task test(HttpContext context)
        {
             await context.Response.WriteAsync("before request");
        }
        public  async Task testD(HttpContext context, Func<Task> T1)
        {
           await context.Response.WriteAsync("from testD");
        }
    }
}
