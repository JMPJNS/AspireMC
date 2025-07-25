using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace AspireMC.Config.Modpack;

public class ModrinthModpack : IModpack
{
    private string _source;
    private string? _allowedVersionType;
    private string? _downloadDependencies;

    public ModrinthModpack(string source)
    {
        _source = source;
    }

    /// <summary>
    /// https://docker-minecraft-server.readthedocs.io/en/latest/mods-and-plugins/modrinth/#extra-options
    /// </summary>
    /// <param name="allowedVersionType">release (default), beta, alpha</param>
    /// <returns></returns>
    public ModrinthModpack WithAllowedVersionType(string allowedVersionType)
    {
        _allowedVersionType = allowedVersionType;
        return this;
    }

    /// <summary>
    /// https://docker-minecraft-server.readthedocs.io/en/latest/mods-and-plugins/modrinth/#extra-options
    /// </summary>
    /// <param name="downloadDependencies"></param>
    /// <returns>none, required or optional (default)</returns>
    public ModrinthModpack WithDownloadDependencies(string downloadDependencies)
    {
        _downloadDependencies = downloadDependencies;
        return this;
    }

    public IResourceBuilder<MinecraftResource> SetResourceParameters(IResourceBuilder<MinecraftResource> builder)
    {
        builder.WithEnvironment("TYPE", "MODRINTH");
        builder.WithEnvironment("MODRINTH_MODPACK", _source);
        if (_allowedVersionType != null)
            builder.WithEnvironment("MODRINTH_ALLOWED_VERSION_TYPE", _allowedVersionType);
        if (_downloadDependencies != null)
            builder.WithEnvironment("MODRINTH_DOWNLOAD_DEPENDENCIES", _downloadDependencies);
        return builder;
    }
}