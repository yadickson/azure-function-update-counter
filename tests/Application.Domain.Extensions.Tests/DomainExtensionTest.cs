using Application.Domain.Abstractions.UseCase;
using Application.Domain.UseCase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Application.Domain.Extensions.Tests;

[TestClass]
public sealed class DomainExtensionTest
{
    private readonly int _count = 1;

    [TestMethod]
    public void Should_Check_How_Many_Services_Were_Add()
    {
        var services = new ServiceCollection();

        services.DomainConfiguration();

        Assert.AreEqual(_count, services.Count);
    }

    [TestMethod]
    public void Should_Check_If_AddScope_UpdateCounterUseCase_Was_Add()
    {
        var services = new ServiceCollection();

        services.DomainConfiguration();

        services.TryAddScoped<IUpdateCounterUseCase, UpdateCounterUseCase>();

        Assert.AreEqual(_count, services.Count);
    }
}