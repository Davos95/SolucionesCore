using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeguridadMicrosoft.Data;

namespace SeguridadMicrosoft
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            String cmsString = configuration["Hospital:ConnectionString"];
            services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(cmsString));/*this.configuration.GetConnectionString("cadenaaspnet")*/


            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AplicationDbContext>();

            String clientid = configuration["Authentication:Microsoft:ApplicationId"];
            String secret = configuration["Authentication:Microsoft:Password"];


            //CONFIGURAR LA SEGURIDAD DEL PROVEEDOR
            services.AddAuthentication().AddMicrosoftAccount(options =>
            {
                options.ClientId = clientid; /* "aacb3ca8-35d2-4d7f-8131-7d1857ff810f";*/
                options.ClientSecret = secret; /* "daDI12202dvkxyKLFEU=}+}";*/
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //1
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //4
            app.UseStaticFiles();

            //6
            app.UseAuthentication();

            //8
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
