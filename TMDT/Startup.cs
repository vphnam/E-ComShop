using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TMDT.Application;
using TMDT.Helpers;
using TMDT.Infrastructure;
using TMDT.Mapper;

namespace TMDT
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
            //allow request
            services.AddCors(builder =>
            {
                builder.AddPolicy("LocalDevCors", options =>
                {
                    options.WithOrigins(Configuration["SAPHost:url"]).AllowAnyHeader().AllowAnyMethod();
                });
                builder.AddPolicy("LocalClient", options =>
                {
                    options.WithOrigins(Configuration["SAPHost:url2"]).AllowAnyHeader().AllowAnyMethod();
                });


            });

            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            ConfigurationInfrastructure(services);
            ConfigurationApplication(services);
            services.AddScoped<Helper, Helper>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMDT", Version = "v1" });
            });
        }
      
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopAPI v1"));
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMDT v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                app.UseCors("LocalDevCors");
                app.UseCors("LocalClient");
                //app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                endpoints.MapControllers(); 
            });
        }
        public void ConfigurationInfrastructure(IServiceCollection services)
        {
            services.AddInfrastructureServices();
        }
        public void ConfigurationApplication(IServiceCollection services)
        {
            services.AddAppServices();
        }
    }
}
