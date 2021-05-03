using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SmartMedArchtOpdracht.Buisiness_Logica.Services;
using SmartMedArchtOpdracht.Buisiness_Logica.Servics.implementations;
using SmartMedArchtOpdracht.Dataacces_Laag.Persisitence;
using SmartMedArchtOpdracht.Dataacces_Laag.Persistence.implementations;

namespace SmartMedArchtOpdracht
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
            services.Configure<PharmacyDatabaseSettings>(
            Configuration.GetSection(nameof(PharmacyDatabaseSettings)));

            // Dependecy Injection
            services.AddScoped<IPharmacyDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PharmacyDatabaseSettings>>().Value);

            services.AddScoped<IMedicineServices, MedicineServices>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartMedArchtOpdracht", Version = "v1" });
            
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartMedArchtOpdracht v1"));
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
