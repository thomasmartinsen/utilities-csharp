using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace Csharp.Configuration;

public abstract class Settings
{
    public Settings(string? defaultConfigFile = null)
    {
        if (defaultConfigFile != null)
        {
            DefaultConfigFile = defaultConfigFile;
        }
    }

    public string DefaultConfigFile { get; set; } = "appsettings.json";

    [JsonPropertyName("logLevel")]
    public LogLevel? LogLevel { get; set; } = Microsoft.Extensions.Logging.LogLevel.Warning;
}
