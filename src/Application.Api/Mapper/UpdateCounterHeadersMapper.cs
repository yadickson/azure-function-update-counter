using Application.Api.Abstractions.Mapper;
using Application.Domain.Abstractions.Model;
using Microsoft.AspNetCore.Http;

namespace Application.Api.Mapper;

internal sealed class UpdateCounterHeadersMapper : IUpdateCounterHeadersMapper
{
    public UpdateCounterHeadersModel FromDtoToModel(HttpRequest? request)
    {
        return new UpdateCounterHeadersModel
        {
            TransactionId = GetTransactionId(request)
        };
    }

    private static string GetTransactionId(HttpRequest? request)
    {
        return request?.Headers["X-Transaction-Id"].FirstOrDefault() ?? "";
    }
}