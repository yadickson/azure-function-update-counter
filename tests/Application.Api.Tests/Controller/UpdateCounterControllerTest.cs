using System.Net;
using Application.Api.Abstractions.Controller;
using Application.Api.Abstractions.Dto;
using Application.Api.Abstractions.Service;
using Application.Api.Controller;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.Api.Tests.Controller;

[TestClass]
public class UpdateCounterControllerTest
{
    private readonly IUpdateCounterController _controller;
    private readonly Faker _faker;
    private readonly Mock<ILogger<UpdateCounterController>> _loggerMock;
    private readonly Mock<IUpdateCounterService> _updateServiceMock;

    public UpdateCounterControllerTest()
    {
        _faker = new Faker();
        _loggerMock = new Mock<ILogger<UpdateCounterController>>();
        _updateServiceMock = new Mock<IUpdateCounterService>();
        _controller = new UpdateCounterController(_loggerMock.Object, _updateServiceMock.Object);
    }

    [TestMethod]
    public async Task Should_Check_In_Order_Call_Dependencies()
    {
        var requestMock = Mock.Of<HttpRequest>();

        var callOrder = 0;

        _loggerMock.Setup(method => method.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ))
            .Callback(() => Assert.AreEqual(1, ++callOrder));

        _updateServiceMock.Setup(method => method.UpdateCounterAsync(It.IsAny<HttpRequest>()))
            .Callback(() => Assert.AreEqual(2, ++callOrder));

        await _controller.Run(requestMock);

        Assert.AreEqual(2, callOrder);
    }

    [TestMethod]
    public async Task Should_Check_Logger_Is_Called_With_Message()
    {
        var requestMock = Mock.Of<HttpRequest>();

        var expected = "Running update counter function.";

        await _controller.Run(requestMock);

        _loggerMock.Verify(method => method.Log(
                It.Is<LogLevel>(level => level == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((message, _) => expected.CompareTo(message.ToString()) == 0),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception?, string>>((_, __) => true)),
            Times.Once());
    }

    [TestMethod]
    public async Task Should_Check_Response_Status()
    {
        var requestMock = Mock.Of<HttpRequest>();
        var responseMock = Mock.Of<UpdateCounterResponseDto>();

        _updateServiceMock.Setup(method => method.UpdateCounterAsync(It.IsAny<HttpRequest>()))
            .ReturnsAsync(responseMock);

        var response = await _controller.Run(requestMock);

        Assert.IsNotNull(response);
        Assert.IsTrue(response is IStatusCodeActionResult);
        Assert.AreEqual((int)HttpStatusCode.OK, ((IStatusCodeActionResult)response).StatusCode);
    }

    [TestMethod]
    public async Task Should_Check_Response_Value()
    {
        var requestMock = Mock.Of<HttpRequest>();
        var responseMock = Mock.Of<UpdateCounterResponseDto>();

        _updateServiceMock.Setup(method => method.UpdateCounterAsync(It.IsAny<HttpRequest>()))
            .ReturnsAsync(responseMock);

        var response = await _controller.Run(requestMock);

        Assert.IsNotNull(response);
        Assert.IsTrue(response is ObjectResult);
        Assert.AreSame(responseMock, ((ObjectResult)response).Value);
    }
}