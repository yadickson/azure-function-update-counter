using Application.Api.Abstractions.Dto;
using Application.Domain.Abstractions.Model;

namespace Application.Api.Abstractions.Mapper;

public interface IUpdateCounterResponseMapper
{
    UpdateCounterResponseDto FromModelToDto(UpdateCounterResponseModel response);
}