using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using AspireMC.Config;

// Put extensions in the Aspire.Hosting namespace to ease discovery as referencing
// the .NET Aspire hosting package automatically adds this namespace.
namespace AspireMC;

public static class MinecraftResourceBuilderExtensions
{
    public static IResourceBuilder<MinecraftResource> AddMinecraft(
        this IDistributedApplicationBuilder builder,
        string name,
        MinecraftConfig config)
    {
        // The AddResource method is a core API within .NET Aspire and is
        // used by resource developers to wrap a custom resource in an
        // IResourceBuilder<T> instance. Extension methods to customize
        // the resource (if any exist) target the builder interface.
        var resource = new MinecraftResource(name, config);

        var containerBuilder = builder.AddResource(resource)
            .WithImage("itzg/minecraft-server")
            .WithImageRegistry("docker.io")
            .WithImageTag(config.JavaVersion)
            .WithEndpoint(config.Port, config.Port);

        containerBuilder.WithEnvironment("MEMORY", config.Ram);
        containerBuilder.WithEnvironment("PORT", config.Port.ToString);

        if (config.Eula)
            containerBuilder.WithEnvironment("EULA", "true");
        else
            throw new Exception("It is required to accept the Minecraft Eula (AcceptEula())");
        
        containerBuilder.WithEnvironment("DIFFICULTY", config.Difficulty);
        if (config.Icon != null)
            containerBuilder.WithEnvironment("ICON", config.Icon);
        if (config.Motd != null)
            containerBuilder.WithEnvironment("MOTD", config.Motd);

        if (config.Modpack != null)
        {
            containerBuilder = config.Modpack.SetResourceParameters(containerBuilder);
        }

        foreach (var envVar in config.EnvironmentVariables)
        {
            containerBuilder.WithEnvironment(envVar.Key, envVar.Value);
        }

        return containerBuilder;
    }
}