using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace AspireMC.Config.Modpack;

public class CurseforgeModpack : IModpack
{
    private string? _url;
    private string? _slug;
    private string _apiKey;

    public CurseforgeModpack(string apiKey, string url)
    {
        _apiKey = apiKey;
        _url = url;
    }

    public CurseforgeModpack(string apiKey)
    {
        _apiKey = apiKey;
    }

    public CurseforgeModpack WithUrl(string url)
    {
        _url = url;
        return this;
    }

    public string WithSlug(string slug)
    {
        _slug = slug;
        return _slug;
    }

    public IResourceBuilder<MinecraftResource> SetResourceParameters(IResourceBuilder<MinecraftResource> builder)
    {
        builder.WithEnvironment("TYPE", "AUTO_CURSEFORGE");
        builder.WithEnvironment("CF_API_KEY", _apiKey);
        if (_slug != null)
        {
            builder.WithEnvironment("CF_SLUG", _slug);
        }
        if (_url != null)
        {
            builder.WithEnvironment("CF_PAGE_URL", _url);
        }
        return builder;
    }
}