using Application.Api.Abstractions.Controller;
using Application.Api.Abstractions.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Application.Api.Controller;

public class UpdateCounterController(ILogger<UpdateCounterController> _logger, IUpdateCounterService _service)
    : IUpdateCounterController
{
    [Function("UpdateCounterFunction")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest? request)
    {
        _logger.LogInformation("Running update counter function.");
        return new OkObjectResult(await _service.UpdateCounterAsync(request));
    }
}