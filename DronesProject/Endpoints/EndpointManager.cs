using DronesProject;

namespace DronesWebApi.Endpoints
{
    public static class EndpointManager
    {
        public static void RegisterServices(IServiceCollection services)
        {
            var typesFromAssemblies = typeof(Program).Assembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(typeof(IEndpointGroup)));
            foreach (var type in typesFromAssemblies)
                services.AddScoped(type);
        }

        public static void RegisterEndpoints(WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                RouteGroupBuilder portalGroup = app.MapGroup("/api/v1/");
                IServiceProvider provider = scope.ServiceProvider;
                var typesFromAssemblies = typeof(Program).Assembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(typeof(IEndpointGroup)));
                foreach (var type in typesFromAssemblies)
                {
                    IEndpointGroup? wrapper = (provider.GetService(type) as IEndpointGroup);
                    wrapper?.RegisterPortalEndpoints(portalGroup);
                }
            }
        }
    }
}
