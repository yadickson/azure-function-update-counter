using Application.Domain.Abstractions.Model;
using Microsoft.AspNetCore.Http;

namespace Application.Api.Abstractions.Mapper;

public interface IUpdateCounterHeadersMapper
{
    UpdateCounterHeadersModel FromDtoToModel(HttpRequest? request);
}