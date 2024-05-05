using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace drones_root
{
    public static class DependencyManager
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            #region Data
            //services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("XposAdminDb")));
            //services.AddScoped<AppDbContext>();

            //services.AddScoped<IDbInitializer, DbInitializer>();
            //services.AddSingleton<ISeeder, XPosAdminDbSeederService>();
            //services.AddSingleton<IGlobalConfigDbSeederService, GlobalConfigDbSeederService>();

            //services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            //services.AddScoped<IXposRepository, XposRepository>();
            //services.AddScoped<IGlobalConfigRepository, GlobalConfigRepository>();
            //services.AddScoped<ILogsRepository, LogsRepository>();
            //services.AddScoped<IContingencyRepository, ContingencyRepository>();
            //services.AddScoped<IVersionRepository, VersionRepository>();
            //services.AddScoped<ICountryRepository, CountryRepository>();

            #endregion

            #region Validators



            #endregion

            #region Business
            //services.AddScoped<IOrganizationService, OrganizationService>();
            //services.AddScoped<IXposService, XposService>();

            //services.AddScoped<IGlobalConfigZipFilesHandler, GlobalConfigZipFilesHandlerService>();
            //services.AddScoped<IGlobalConfigService, GlobalConfigService>();
            //services.AddScoped<IContingencyService, ContingencyService>();
            //services.AddScoped<ILogsService, LogsService>();
            //services.AddScoped<IVersionService, VersionService>();
            //services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<CertificateService, CertificateService>();

            #endregion

            //services.AddSingleton<Localizer>();
        }
    }
}
