using DronesProject;

namespace DronesWebApi.ApiServices
{
    public static class ApiServicesManager
    {
        public static void RegisterServices(IServiceCollection services)
        {
            var typesFromAssemblies = typeof(Program).Assembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(typeof(IApiService)));
            foreach (var type in typesFromAssemblies)
                services.AddScoped(type);
        }
    }
}
