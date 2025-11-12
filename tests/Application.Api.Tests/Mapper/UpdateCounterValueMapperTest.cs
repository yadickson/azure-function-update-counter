using Application.Api.Abstractions.Mapper;
using Application.Api.Mapper;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Application.Api.Tests.Mapper;

[TestClass]
public class UpdateCounterValueMapperTest
{
    private readonly Faker _faker = new();
    private readonly IUpdateCounterValueMapper _mapper = new UpdateCounterValueMapper();

    [TestMethod]
    public void Should_Check_Response_When_Request_Is_Null()
    {
        var request = (HttpRequest?)null;

        var response = _mapper.FromDtoToString(request);

        Assert.IsNull(response);
    }

    [TestMethod]
    public void Should_Check_Response_When_Query_Is_Empty()
    {
        var requesMock = new Mock<HttpRequest>();
        var queryMock = new QueryCollection() as IQueryCollection;

        requesMock.Setup(req => req.Query).Returns(queryMock);

        var response = _mapper.FromDtoToString(requesMock.Object);

        Assert.IsNull(response);
    }

    [TestMethod]
    public void Should_Check_Response_When_Query_Has_Value()
    {
        var requesMock = new Mock<HttpRequest>();
        var value = _faker.Random.String();

        var queryMock = new QueryCollection(
            new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase)
            {
                { "value", value }
            }) as IQueryCollection;

        requesMock.Setup(req => req.Query).Returns(queryMock);

        var response = _mapper.FromDtoToString(requesMock.Object);

        Assert.AreEqual(response, value);
    }
}