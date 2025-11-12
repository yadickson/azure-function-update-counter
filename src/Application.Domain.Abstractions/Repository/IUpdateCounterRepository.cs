using Application.Domain.Abstractions.Model;

namespace Application.Domain.Abstractions.Repository;

public interface IUpdateCounterRepository
{
    Task<UpdateCounterResponseModel> UpdateCounterAsync(UpdateCounterRequestModel request);
}