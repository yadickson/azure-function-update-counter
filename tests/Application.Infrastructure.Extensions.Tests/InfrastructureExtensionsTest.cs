using Application.Domain.Abstractions.Repository;
using Application.Domain.Abstractions.Validator;
using Application.Infrastructure.Abstractions.Configuration;
using Application.Infrastructure.Configuration;
using Application.Infrastructure.Repository;
using Application.Infrastructure.Validator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Application.Infrastructure.Extensions.Tests;

[TestClass]
public sealed class InfrastructureExtensionTest
{
    private readonly int _count = 3;

    [TestMethod]
    public void Should_Check_How_Many_Services_Were_Add()
    {
        var services = new ServiceCollection();

        services.InfrastructureConfiguration();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_DatabaseConfiguration_Was_Add()
    {
        var services = new ServiceCollection();

        services.InfrastructureConfiguration();

        services.TryAddScoped<IDatabaseConfiguration, DatabaseConfiguration>();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterRequestValidator_Was_Add()
    {
        var services = new ServiceCollection();

        services.InfrastructureConfiguration();

        services.TryAddScoped<IUpdateCounterRequestValidator, UpdateCounterRequestValidator>();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterRepository_Was_Add()
    {
        var services = new ServiceCollection();

        services.InfrastructureConfiguration();

        services.TryAddScoped<IUpdateCounterRepository, UpdateCounterRepository>();

        Assert.AreEqual(_count, services.Count);
    }
}