using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stocks_api.Repository;
using stocks_api.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace stocks_api
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddAutoMapper();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            // register the DbContext on the container, getting the connection string from
            // appSettings (note: use this during development; in a production environment,
            // it's better to store the connection string in an environment variable)
            var connectionString = Configuration["ConnectionStrings:MoviesDBConnectionString"];
            //services.AddDbContext<MoviesContext>(o => o.UseSqlServer(connectionString));

            //services.AddScoped<IMoviesRepository, MoviesRepository>();
            //services.AddScoped<IPostersRepository, PostersRepository>();
            //services.AddScoped<ITrailersRepository, TrailersRepository>();
            services.AddScoped<IGlobalQuotesService, GlobalQuotesService>();
            services.AddScoped<IGlobalQuotesRepository, GlobalQuotesRepository>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Global Quotes API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Movies API (v1)");
                // serve UI at root
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
