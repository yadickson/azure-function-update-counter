using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Abstractions.Controller;

public interface IUpdateCounterController
{
    Task<IActionResult> Run(HttpRequest? request);
}