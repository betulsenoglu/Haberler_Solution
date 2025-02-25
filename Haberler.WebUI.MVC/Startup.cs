﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Haberler.WebUI.MVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            
                /// <summary>
                /// Case gerekliliklerinde belirlenen url pattern bu noktada konfigure edilmistir. 
                /// </summary>
                app.UseMvc(routes =>
            {
                routes.MapRoute("AMPSelected", "amp/haberler",
                          defaults: new { controller = "Home", action = "AMPHaberler" });
                routes.MapRoute("AMPIndex", "amp/haberler-{id}",
                          defaults: new { controller = "Home", action = "AMPSelectedNews" });
                routes.MapRoute("IndexSelected", "haberler-{id}",
                          defaults: new { controller = "Home", action = "SelectedNews" });
                routes.MapRoute("Index", "haberler/",
                          defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
