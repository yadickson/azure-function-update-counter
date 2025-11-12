using Application.Domain.Abstractions.Model;
using Microsoft.AspNetCore.Http;

namespace Application.Api.Abstractions.Mapper;

public interface IUpdateCounterRequestMapper
{
    UpdateCounterRequestModel FromDtoToModel(HttpRequest? request);
}