using FluentValidation.AspNetCore;
using IComp.Core;
using IComp.Data;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.Implementations;
using IComp.Service.Interfaces;
using IComp.Service.Profiles;
using IComp.ServiceExtentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddDbContext<StoreDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Default"));
            }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProcessorPostDTOValidator>());
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProcessorService, ProcessorService>();
            services.AddScoped<IProcessorSerieService, ProcessorSerieService>();
            services.AddScoped<IVideoCardService, VideoCardService>();
            services.AddScoped<IVCSerieService, VCSerieService>();
            services.AddScoped<IMemoryService, MemoryService>();
            services.AddScoped<IMemoryCapacityService, MemoryCapacityService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(cnf =>
            {
                cnf.AddProfile(new MapProfile());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.ExceptionHandler();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Areas",
                   pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
