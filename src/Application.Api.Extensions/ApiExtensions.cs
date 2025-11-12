using Application.Api.Abstractions.Mapper;
using Application.Api.Abstractions.Service;
using Application.Api.Mapper;
using Application.Api.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Api.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection ApiConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IUpdateCounterHeadersMapper, UpdateCounterHeadersMapper>();
        services.AddScoped<IUpdateCounterValueMapper, UpdateCounterValueMapper>();
        services.AddScoped<IUpdateCounterRequestMapper, UpdateCounterRequestMapper>();
        services.AddScoped<IUpdateCounterResponseMapper, UpdateCounterResponseMapper>();
        services.AddScoped<IUpdateCounterService, UpdateCounterService>();

        return services;
    }
}