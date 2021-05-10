#region snippet_UsingPointsApiMongoDBModels
using PointsApiMongoDB.Models;
#endregion
#region snippet_UsingPointsApiMongoDBServices
using PointsApiMongoDB.Services;
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PointsApiMongoDB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<PointstoreDatabaseSettings>(
                Configuration.GetSection(nameof(PointstoreDatabaseSettings)));

            services.AddSingleton<IPointstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PointstoreDatabaseSettings>>().Value);

            services.AddSingleton<PointService>();

            services.Configure<OrderstoreDatabaseSettings>(
                Configuration.GetSection(nameof(OrderstoreDatabaseSettings)));

            services.AddTransient<IOrderstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<OrderstoreDatabaseSettings>>().Value);

            services.AddTransient<OrderService>();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing());
        }
        #endregion

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
