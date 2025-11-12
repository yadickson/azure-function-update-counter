using Application.Api.Abstractions.Dto;
using Application.Api.Abstractions.Mapper;
using Application.Domain.Abstractions.Model;

namespace Application.Api.Mapper;

internal sealed class UpdateCounterResponseMapper : IUpdateCounterResponseMapper
{
    public UpdateCounterResponseDto FromModelToDto(UpdateCounterResponseModel response)
    {
        return new UpdateCounterResponseDto();
    }
}