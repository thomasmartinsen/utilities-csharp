using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace Csharp.OpenAI.Configuration;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds a chat completion service to the list. It can be either an OpenAI or Azure OpenAI backend service.
    /// </summary>
    /// <param name="kernelBuilder"></param>
    /// <param name="settings"></param>
    /// <exception cref="ArgumentException"></exception>
    public static IServiceCollection AddChatCompletionService(this IServiceCollection serviceCollection, OpenAISettings settings)
    {
        switch (settings.ServiceType.ToUpperInvariant())
        {
            case ServiceTypes.AzureOpenAI:
                serviceCollection = serviceCollection.AddAzureOpenAIChatCompletion(settings.DeploymentId, settings.ModelId, endpoint: settings.Endpoint, apiKey: settings.ApiKey, serviceId: settings.ServiceId);
                break;

            case ServiceTypes.OpenAI:
                serviceCollection = serviceCollection.AddOpenAIChatCompletion(modelId: settings.ModelId, apiKey: settings.ApiKey, orgId: settings.OrgId, serviceId: settings.ServiceId);
                break;

            default:
                throw new ArgumentException($"Invalid service type value: {settings.ServiceType}");
        }

        return serviceCollection;
    }
}
