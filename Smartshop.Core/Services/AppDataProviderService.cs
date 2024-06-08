using Smartshop.Core.Enum;
using Smartshop.Core.Interfaces;
using Smartshop.Core.Models;
using System;
using System.IO;
using System.Text.Json;

namespace Smartshop.Core.Services
{
    public class AppDataProviderService : IDataProvider
    {
        public Result<string, SystemError> GetConnectionString()
        {
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "config.json");
            var json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<ConfigJson>(json)!.ConnectionString;

            if (config is null)
            {
                var error = new SystemError
                {
                    ErrorCode = Guid.NewGuid(),
                    ErrorMessage = "could not fetch connection string",
                    ErrorType = ErrorType.CONNECTION,
                    Timestamp = DateTime.UtcNow
                };

                return Result<string, SystemError>.Err(error)!;
                
            }
            return Result<string, SystemError>.Ok(config!)!;
        }
    }
}
