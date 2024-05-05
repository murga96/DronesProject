using drones_root;
using DronesWebApi.ApiServices;
using DronesWebApi.Endpoints;

namespace DronesProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigurationManager configuration = builder.Configuration;
            DependencyManager.InjectDependencies(builder.Services, configuration);
            EndpointManager.RegisterServices(builder.Services);
            ApiServicesManager.RegisterServices(builder.Services);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("doc", new() { Title = $"{builder.Environment.ApplicationName}", Version = "v1" });//xPOS Admin API
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.EnableTryItOutByDefault();
                options.SwaggerEndpoint($"/swagger/doc/swagger.json", $"{builder.Environment.ApplicationName} v1");//{builder.Environment.ApplicationName}
            });
            app.UseCors();

            EndpointManager.RegisterEndpoints(app);
            app.Run();
        }
    }
}
