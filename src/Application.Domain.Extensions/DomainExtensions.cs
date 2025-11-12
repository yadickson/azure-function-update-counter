using Application.Domain.Abstractions.UseCase;
using Application.Domain.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Domain.Extensions;

public static class DomainExtensions
{
    public static IServiceCollection DomainConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IUpdateCounterUseCase, UpdateCounterUseCase>();

        return services;
    }
}