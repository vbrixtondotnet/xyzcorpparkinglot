using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using XYZCorp.ParkingLot.BusinessLogic;
using XYZCorp.ParkingLot.BusinessLogic.Interfaces;
using XYZCorp.ParkingLot.DataStore.Interfaces;
using XYZCorp.ParkingLot.DataStore.SQL;

namespace AYZCorp.ParkingLot.API 
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
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                ).AddJsonOptions( options => {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddDbContext<SqlDbContext>(o =>
            {
                o.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            }, ServiceLifetime.Transient);

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IEntryPointDataStore, EntryPointDataStore>();
            services.AddScoped<ISlotDataStore, SlotDataStore>();
            services.AddScoped<IParkingDataStore, ParkingDataStore>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IParkingBL, ParkingBL>();
            services.AddScoped<ISlotBL, SlotBL>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AYZCorp ParkingLot API v1");
            });
        }
    }
}
