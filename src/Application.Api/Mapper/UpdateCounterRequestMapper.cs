using Application.Api.Abstractions.Mapper;
using Application.Domain.Abstractions.Model;
using Microsoft.AspNetCore.Http;

namespace Application.Api.Mapper;

internal sealed class UpdateCounterRequestMapper(
    IUpdateCounterHeadersMapper _headersMapper,
    IUpdateCounterValueMapper _valueMapper)
    : IUpdateCounterRequestMapper
{
    public UpdateCounterRequestModel FromDtoToModel(HttpRequest? request)
    {
        return new UpdateCounterRequestModel
        {
            Headers = GetHeaders(request),
            Value = GetValue(request)
        };
    }

    private UpdateCounterHeadersModel GetHeaders(HttpRequest? request)
    {
        return _headersMapper.FromDtoToModel(request);
    }

    private string? GetValue(HttpRequest? request)
    {
        return _valueMapper.FromDtoToString(request);
    }
}