namespace Application.Domain.Abstractions.Model;

public class UpdateCounterRequestModel
{
    public required UpdateCounterHeadersModel Headers;
    public required string? Value { init; get; }
}