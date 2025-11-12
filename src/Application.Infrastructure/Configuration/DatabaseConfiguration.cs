using Application.Infrastructure.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

namespace Application.Infrastructure.Configuration;

internal sealed class DatabaseConfiguration(IConfiguration _configuration) : IDatabaseConfiguration
{
    public string GetConnectionString()
    {
        return _configuration["DB_CONNECTION_STRING"] ??
               throw new Exception("DB_CONNECTION_STRING environment not found.");
    }
}