using Application.Api.Abstractions.Mapper;
using Application.Api.Mapper;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Application.Api.Tests.Mapper;

[TestClass]
public class UpdateCounterHeadersMapperTest
{
    private readonly Faker _faker = new();
    private readonly IUpdateCounterHeadersMapper _mapper = new UpdateCounterHeadersMapper();

    [TestMethod]
    public void Should_Check_Response_When_Request_Is_Null()
    {
        var request = (HttpRequest?)null;

        var response = _mapper.FromDtoToModel(request);

        Assert.IsNotNull(response);
    }

    [TestMethod]
    public void Should_Check_TransactionId_When_Request_Is_Null()
    {
        var request = (HttpRequest?)null;

        var response = _mapper.FromDtoToModel(request);

        Assert.IsNotNull(response);
        Assert.AreEqual("", response.TransactionId);
    }

    [TestMethod]
    public void Should_Check_TransactionId_When_Headers_Is_Empty()
    {
        var requesMock = new Mock<HttpRequest>();
        var headersMock = new HeaderDictionary() as IHeaderDictionary;

        requesMock.Setup(req => req.Headers).Returns(headersMock);

        var response = _mapper.FromDtoToModel(requesMock.Object);

        Assert.IsNotNull(response);
        Assert.AreEqual("", response.TransactionId);
    }

    [TestMethod]
    public void Should_Check_TransactionId_When_Headers_Has_XTransactionId()
    {
        var transactionId = _faker.Random.Uuid().ToString();
        var requesMock = new Mock<HttpRequest>();
        var headersMock = new HeaderDictionary(
            new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase)
            {
                { "x-transaction-id", transactionId }
            }
        ) as IHeaderDictionary;

        requesMock.Setup(req => req.Headers).Returns(headersMock);

        var response = _mapper.FromDtoToModel(requesMock.Object);

        Assert.IsNotNull(response);
        Assert.AreEqual(transactionId, response.TransactionId);
    }
}