using Application.Api.Abstractions.Dto;
using Application.Api.Abstractions.Mapper;
using Application.Api.Abstractions.Service;
using Application.Domain.Abstractions.UseCase;
using Microsoft.AspNetCore.Http;

namespace Application.Api.Service;

internal sealed class UpdateCounterService(
    IUpdateCounterRequestMapper _requestMapper,
    IUpdateCounterUseCase _useCase,
    IUpdateCounterResponseMapper _responseMapper) : IUpdateCounterService
{
    public async Task<UpdateCounterResponseDto> UpdateCounterAsync(HttpRequest? request)
    {
        var requestModel = _requestMapper.FromDtoToModel(request);
        var responseModel = await _useCase.ExecuteAsync(requestModel);
        return _responseMapper.FromModelToDto(responseModel);
    }
}