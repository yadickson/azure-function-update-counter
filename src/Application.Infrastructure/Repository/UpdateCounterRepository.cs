using Application.Domain.Abstractions.Model;
using Application.Domain.Abstractions.Repository;
using Application.Infrastructure.Abstractions.Configuration;

namespace Application.Infrastructure.Repository;

internal sealed class UpdateCounterRepository(IDatabaseConfiguration _configuration) : IUpdateCounterRepository
{
    public Task<UpdateCounterResponseModel> UpdateCounterAsync(UpdateCounterRequestModel request)
    {
        Console.WriteLine(_configuration.GetConnectionString());
        return Task.FromResult(new UpdateCounterResponseModel());
    }
}