using Application.Domain.Abstractions.Model;
using Application.Domain.Abstractions.Validator;

namespace Application.Infrastructure.Validator;

internal sealed class UpdateCounterRequestValidator : IUpdateCounterRequestValidator
{
    public void Validate(UpdateCounterRequestModel request)
    {
        // TODO
    }
}