using Application.Domain.Abstractions.Model;
using Application.Domain.Abstractions.Repository;
using Application.Domain.Abstractions.UseCase;
using Application.Domain.Abstractions.Validator;
using Microsoft.Extensions.Logging;

namespace Application.Domain.UseCase;

internal sealed class UpdateCounterUseCase(
    ILogger<UpdateCounterUseCase> _logger,
    IUpdateCounterRequestValidator _validator,
    IUpdateCounterRepository _repository) : IUpdateCounterUseCase
{
    public async Task<UpdateCounterResponseModel> ExecuteAsync(UpdateCounterRequestModel request)
    {
        _logger.LogInformation("Updating counter.");
        _validator.Validate(request);
        return await _repository.UpdateCounterAsync(request);
    }
}