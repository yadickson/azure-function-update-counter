using Application.Api.Abstractions.Mapper;
using Microsoft.AspNetCore.Http;

namespace Application.Api.Mapper;

public class UpdateCounterValueMapper : IUpdateCounterValueMapper
{
    public string? FromDtoToString(HttpRequest? request)
    {
        return request?.Query["Value"].FirstOrDefault();
    }
}