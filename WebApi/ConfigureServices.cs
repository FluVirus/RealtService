using Microsoft.OpenApi.Models;
using RealtService.Application.Common.Mappings;
using RealtService.WebApi.Middleware;

namespace RealtService.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GeneralProfile));
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "RealtService API",
                Version = "v1",
                Description = "Realt Service",
                Contact = new OpenApiContact
                {
                    Name = "Konanau Aliaksandr",
                    Email = "m.kononov.alexander@gmail.com"
                },
            });
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        services.AddControllersWithViews();
        services.AddSingleton<GlobalErrorHandler>();
        return services;
    }
}
