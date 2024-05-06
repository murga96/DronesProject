using drones_business.Impl;
using drones_business.Services;
using drones_data;
using drones_data.Impl;
using drones_data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace drones_root
{
    public static class DependencyManager
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            #region Data
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Db")));
            services.AddScoped<AppDbContext>();
            services.AddScoped<IDroneRepository, DroneRepository>();

            #endregion

            #region Validators



            #endregion

            #region Business
            services.AddScoped<IDroneService, DroneService>();

            #endregion

            //services.AddSingleton<Localizer>();
        }
    }
}
