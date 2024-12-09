using Application;
using BonsaiForum.Grpc;
using GrpcWikiService.Services;
using Infrastructure;

namespace GrpcWikiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();

            // Add repository and database context services
            builder.Services.AddApplication().AddInfrastructure();

            // Add other necessary services (e.g., logging, caching)
            builder.Services.AddMemoryCache(); // For in-memory caching
            //builder.Services.AddSingleton<ICacheService, CacheService>(); // Example custom cache service

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<WikiServiceImpl>();
            app.MapGrpcService<GreeterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}