namespace Application.Infrastructure.Abstractions.Configuration;

public interface IDatabaseConfiguration
{
    string GetConnectionString();
}