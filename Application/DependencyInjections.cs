using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using System.Net.NetworkInformation;
using RealtService.Application.Offers;

namespace RealtService.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
