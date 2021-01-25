using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmsterdamSportInc.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AmsterdamSportInc
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
            services.AddDbContext<AmsterdamSportIncContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("AmsterdamSportIncConnection")));
            services.AddControllers();
            services.AddScoped<ISportRepository, SportRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberToSportRepository, MemberToSportRepository>();
            
            //I will let this here in case needed
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "AmsterdamSportInc", Version = "v1" });
            // });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Same here, in case we need swagger
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AmsterdamSportInc v1"));
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
