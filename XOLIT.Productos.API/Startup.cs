
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using XOLIT.Productos.Infrastructure.DBContext;

namespace XOLIT.Productos.API
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

            string connection = Configuration.GetConnectionString("PanelBIDbContext");
            services.AddDbContext<XolitDbContext>(options => options.UseSqlServer(connection).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            #region Swagger
            // Register the Swagger generator, defining one or more Swagger documents

            services.AddSwaggerGen(swagger =>
            {
                var contact = new OpenApiContact
                {
                    Name = "XOLIT Productos API"

                };
                swagger.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "XOLIT.Productos.API",
                    Version = "v1",
                    Description = "XOLIT Productos API  - Documentation Services",
                    Contact = contact

                });
            });
            services.AddControllers();
            #endregion
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Panel.BI.Integraciones.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
