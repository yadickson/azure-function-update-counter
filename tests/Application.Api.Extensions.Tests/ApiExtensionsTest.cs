using Application.Api.Abstractions.Mapper;
using Application.Api.Abstractions.Service;
using Application.Api.Mapper;
using Application.Api.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Application.Api.Extensions.Tests;

[TestClass]
public sealed class ApiExtensionTest
{
    private readonly int _count = 5;

    [TestMethod]
    public void Should_Check_How_Many_Services_Were_Add()
    {
        var services = new ServiceCollection();

        services.ApiConfiguration();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterHeadersMapper_Was_Add()
    {
        var services = new ServiceCollection();

        services.ApiConfiguration();

        services.TryAddScoped<IUpdateCounterHeadersMapper, UpdateCounterHeadersMapper>();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterValueMapper_Was_Add()
    {
        var services = new ServiceCollection();

        services.ApiConfiguration();

        services.TryAddScoped<IUpdateCounterValueMapper, UpdateCounterValueMapper>();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterRequestMapper_Was_Add()
    {
        var services = new ServiceCollection();

        services.ApiConfiguration();

        services.TryAddScoped<IUpdateCounterRequestMapper, UpdateCounterRequestMapper>();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterResponseMapper_Was_Add()
    {
        var services = new ServiceCollection();

        services.ApiConfiguration();

        services.TryAddScoped<IUpdateCounterResponseMapper, UpdateCounterResponseMapper>();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterService_Was_Add()
    {
        var services = new ServiceCollection();

        services.ApiConfiguration();

        services.TryAddScoped<IUpdateCounterService, UpdateCounterService>();

        Assert.AreEqual(_count, services.Count);
    }
}