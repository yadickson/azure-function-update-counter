using Application.Domain.Abstractions.Repository;
using Application.Domain.Abstractions.Validator;
using Application.Infrastructure.Abstractions.Configuration;
using Application.Infrastructure.Configuration;
using Application.Infrastructure.Repository;
using Application.Infrastructure.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseConfiguration, DatabaseConfiguration>();
        services.AddScoped<IUpdateCounterRequestValidator, UpdateCounterRequestValidator>();
        services.AddScoped<IUpdateCounterRepository, UpdateCounterRepository>();

        return services;
    }
}