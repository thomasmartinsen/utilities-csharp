using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace Configuration;

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
