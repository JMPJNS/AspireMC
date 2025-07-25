using Aspire.Hosting.ApplicationModel;

namespace AspireMC.Config.Modpack;

public interface IModpack
{
    public IResourceBuilder<MinecraftResource> SetResourceParameters(IResourceBuilder<MinecraftResource> builder);
}