using RealtService.Application;
using RealtService.Identity;
using RealtService.Persistence;
using RealtService.WebApi.Middleware;
using System.Net;

namespace RealtService.WebApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        //builder.WebHost.UseKestrel(options => options.Listen(IPAddress.Loopback, 80));
        builder.Services
            .AddPersistenceServices(configuration)
            .AddApplicationServices()
            .AddWebApiServices()
            .AddIdentityServices(configuration);

        WebApplication app = builder.Build();
      //  app.UseMiddleware<GlobalErrorHandler>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("AllowAll");
        app.MapControllers();

        //TODO: Think please how we can implement it properly
        using IServiceScope scope = app.Services.CreateScope();
        IServiceProvider services = scope.ServiceProvider;
        RealtServiceDbContextInitializer initialiser = services.GetRequiredService<RealtServiceDbContextInitializer>();
        await initialiser.InitializeDatabaseAsync(configuration);

        await app.RunAsync();
    }
}