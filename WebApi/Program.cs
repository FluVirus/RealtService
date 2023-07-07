using RealtService.Application;
using RealtService.Identity;
using RealtService.Persistence;
using RealtService.WebApi.Middleware;

namespace RealtService.WebApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services
            .AddPersistenceServices(builder.Configuration)
            .AddApplicationServices()
            .AddWebApiServices()
            .AddIdentityServices(builder.Configuration);

        WebApplication app = builder.Build();

        app.UseMiddleware<GlobalErrorHandler>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("AllowAll");
        app.MapControllers();

        using IServiceScope scope = app.Services.CreateScope();
        IServiceProvider services = scope.ServiceProvider;
        RealtServiceDbContextInitializer initialiser = services.GetRequiredService<RealtServiceDbContextInitializer>();
        await initialiser.InitializeDatabaseAsync(builder.Configuration);

        await app.RunAsync();
    }
}