using Application.Api.Abstractions.Dto;
using Microsoft.AspNetCore.Http;

namespace Application.Api.Abstractions.Service;

public interface IUpdateCounterService
{
    Task<UpdateCounterResponseDto> UpdateCounterAsync(HttpRequest? request);
}