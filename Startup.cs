using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using QuadClinicWebApplication2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadClinicWebApplication2022.Repository;

namespace QuadClinicWebApplication2022
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
            services.AddControllers();
        
            //Add dependency Injection for EmployeeDbContext
            services.AddDbContext<QuadClinicContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("QuadClinicConnection")));
            //the rest of services
            //ADDING SERVICES
            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    //enables text json - Display the exact match
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //enables to avoid infinitive loop - Recursive
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            //add service for repository layer
            services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
            //Enable Cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Add Cors
            app.UseCors(options =>
            options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
