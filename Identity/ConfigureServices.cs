using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RealtService.Application.Common.JWT;
using System.Text;

namespace RealtService.Identity;

public static class ConfigureServices
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();
        services.AddSingleton<IJwtTokenValidationProvider, JwtTokenValidationProvider>(factory => new JwtTokenValidationProvider(configuration));
        return services;
    }
}
