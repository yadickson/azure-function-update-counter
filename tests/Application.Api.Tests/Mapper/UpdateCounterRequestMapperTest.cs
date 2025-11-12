using Application.Api.Abstractions.Mapper;
using Application.Api.Mapper;
using Application.Domain.Abstractions.Model;
using Bogus;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Application.Api.Tests.Mapper;

[TestClass]
public class UpdateCounterRequestMapperTest
{
    private readonly Faker _faker = new();
    private readonly Mock<IUpdateCounterHeadersMapper> _headersMapperMock;
    private readonly IUpdateCounterRequestMapper _mapper;
    private readonly Mock<IUpdateCounterValueMapper> _valueMapperMock;

    public UpdateCounterRequestMapperTest()
    {
        _headersMapperMock = new Mock<IUpdateCounterHeadersMapper>();
        _valueMapperMock = new Mock<IUpdateCounterValueMapper>();
        _mapper = new UpdateCounterRequestMapper(_headersMapperMock.Object, _valueMapperMock.Object);
    }

    [TestMethod]
    public void Should_Check_In_Order_Call_Dependencies()
    {
        var requestMock = Mock.Of<HttpRequest>();

        var callOrder = 0;

        _headersMapperMock.Setup(method => method.FromDtoToModel(It.IsAny<HttpRequest>()))
            .Callback(() => Assert.AreEqual(1, ++callOrder));

        _valueMapperMock.Setup(method => method.FromDtoToString(It.IsAny<HttpRequest>()))
            .Callback(() => Assert.AreEqual(2, ++callOrder));

        _mapper.FromDtoToModel(requestMock);

        Assert.AreEqual(2, callOrder);
    }

    [TestMethod]
    public void Should_Check_Headers_Request_Parameters()
    {
        var requestMock = Mock.Of<HttpRequest>();

        _mapper.FromDtoToModel(requestMock);

        _headersMapperMock.Verify(method => method.FromDtoToModel(requestMock), Times.Once());
    }

    [TestMethod]
    public void Should_Check_Value_Request_Parameters()
    {
        var requestMock = Mock.Of<HttpRequest>();

        _mapper.FromDtoToModel(requestMock);

        _valueMapperMock.Verify(method => method.FromDtoToString(requestMock), Times.Once());
    }

    [TestMethod]
    public void Should_Check_Response()
    {
        var requestMock = Mock.Of<HttpRequest>();
        var headersMock = Mock.Of<UpdateCounterHeadersModel>();
        var value = _faker.Random.String();

        _headersMapperMock.Setup(method => method.FromDtoToModel(It.IsAny<HttpRequest>())).Returns(headersMock);
        _valueMapperMock.Setup(method => method.FromDtoToString(It.IsAny<HttpRequest>())).Returns(value);

        var response = _mapper.FromDtoToModel(requestMock);

        Assert.IsNotNull(response);
        Assert.AreEqual(headersMock, response.Headers);
        Assert.AreEqual(value, response.Value);
    }
}