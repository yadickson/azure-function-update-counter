using Microsoft.AspNetCore.Http;

namespace Application.Api.Abstractions.Mapper;

public interface IUpdateCounterValueMapper
{
    string? FromDtoToString(HttpRequest? request);
}