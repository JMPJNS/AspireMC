using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AspireMC;

public class MinecraftVersionsParser(HttpClient httpClient)
{
    public async Task<IEnumerable<VersionInfo>> GetAllMinecraftVersions()
    {
        var versionManifest = JsonSerializer.Deserialize<JsonObject>(await httpClient.GetStringAsync("https://launchermeta.mojang.com/mc/game/version_manifest.json"));
        var versions = versionManifest["versions"]
            .AsArray()
            .Select(v => v.Deserialize<VersionInfo>());

        return versions;
    }

    public record VersionInfo
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}

