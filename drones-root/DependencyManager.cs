using drones_data;
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

            #endregion

            #region Validators



            #endregion

            #region Business

            #endregion

            //services.AddSingleton<Localizer>();
        }
    }
}
