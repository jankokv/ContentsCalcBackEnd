using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentsCalcBackEnd.Core;
using ContentsCalcBackEnd.Logic;
using ContentsCalcBackEnd.Logic.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContentsCalcBackEnd
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
            //Set the connection string
            CalculatorDbContext.ConnectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<CalculatorDbInitializer>();
            services.AddScoped<ICalculatorService, CalculatorService>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCors("MyPolicy");
            app.UseMvc();

            //Applies any pending migrations for the context to the database. Do not use update-database
            using (var ctx = new CalculatorDbContext())
            {
                ctx.Database.Migrate();
            }
            //Seed data
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var init = scope.ServiceProvider.GetService<CalculatorDbInitializer>();
                init.Seed(new CalculatorDbContext());
            }

            
        }
    }
}
