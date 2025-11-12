using Application.Domain.Abstractions.Model;

namespace Application.Domain.Abstractions.UseCase;

public interface IUpdateCounterUseCase
{
    Task<UpdateCounterResponseModel> ExecuteAsync(UpdateCounterRequestModel request);
}