    using Application;
using Application.Interfaces;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.UnitOfWork;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddApplication();
            services.AddPersistence(Configuration);
            
            services.AddSwaggerGen();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      policy =>
            //                      {
            //                          policy.WithOrigins("http://localhost:44323").AllowAnyHeader()
            //                                                  .AllowAnyMethod(); ;
            //                      });
            //});



            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins(Configuration["App:CorsOrigins"].Split(',').ToArray())
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors("AllowOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}