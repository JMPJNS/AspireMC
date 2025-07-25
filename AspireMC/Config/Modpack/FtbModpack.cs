using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace AspireMC.Config.Modpack;

public class FtbModpack : IModpack
{
    /// <summary>
    /// https://docker-minecraft-server.readthedocs.io/en/latest/types-and-platforms/mod-platforms/ftb/#environment-variables
    /// </summary>
    private string _modpackId;
    /// <summary>
    /// https://docker-minecraft-server.readthedocs.io/en/latest/types-and-platforms/mod-platforms/ftb/#environment-variables
    /// </summary>
    private string? _versionId = null;

    /// <summary>
    /// https://docker-minecraft-server.readthedocs.io/en/latest/types-and-platforms/mod-platforms/ftb/#environment-variables
    /// </summary>
    private bool _forceReinstall = false;

    public FtbModpack(string modpackId)
    {
        _modpackId = modpackId;
    }

    public FtbModpack WithVersionId(string versionId)
    {
        _versionId = versionId;
        return this;
    }
    
    public FtbModpack WithForceReinstall(bool forceReinstall)
    {
        _forceReinstall = forceReinstall;
        return this;
    }

    public IResourceBuilder<MinecraftResource> SetResourceParameters(IResourceBuilder<MinecraftResource> builder)
    {
        builder.WithEnvironment("TYPE", "FTBA");
        builder.WithEnvironment("FTB_MODPACK_ID", _modpackId);
        if (_versionId != null)
            builder.WithEnvironment("FTB_MODPACK_VERSION_ID", _versionId);
        if (_forceReinstall)
            builder.WithEnvironment("FTB_MODPACK_REINSTALL", "true");
        
        return builder;
    }
}