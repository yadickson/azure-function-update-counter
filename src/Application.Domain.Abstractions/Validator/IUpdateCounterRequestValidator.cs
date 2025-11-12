using Application.Domain.Abstractions.Model;

namespace Application.Domain.Abstractions.Validator;

public interface IUpdateCounterRequestValidator
{
    void Validate(UpdateCounterRequestModel request);
}