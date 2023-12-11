using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Csharp.Configuration;

public static class LoadSettings
{
    /// <summary>
    /// Load the kernel settings from settings.json if the file exists and if not attempt to use user secrets.
    /// </summary>
    public static T Load<T>() where T : Settings, new()
    {
        T instance = new();
        var configFileName = instance.DefaultConfigFile;

        try
        {
            if (File.Exists(configFileName))
            {
                return FromFile<T>(configFileName);
            }

            return FromUserSecrets<T>();
        }
        catch (InvalidDataException ide)
        {
            Console.Error.WriteLine("Unable to load settings, please provide configuration settings.");
            throw new InvalidOperationException(ide.Message);
        }
    }

    /// <summary>
    /// Load the settings from the specified configuration file if it exists.
    /// </summary>
    internal static T FromFile<T>(string configFile) where T : Settings
    {
        if (!File.Exists(configFile))
        {
            throw new FileNotFoundException($"Configuration not found: {configFile}");
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile(configFile, optional: true, reloadOnChange: true)
            .Build();

        return configuration.Get<T>()
               ?? throw new InvalidDataException($"Invalid settings in '{configFile}'");
    }

    /// <summary>
    /// Load the settings from user secrets.
    /// </summary>
    internal static T FromUserSecrets<T>() where T : Settings
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<T>()
            .Build();

        return configuration.Get<T>()
               ?? throw new InvalidDataException("Invalid settings in user secrets.");
    }
}
