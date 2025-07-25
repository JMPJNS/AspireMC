using AspireMC.Config.Modpack;

namespace AspireMC.Config;

public class MinecraftConfigBuilder
{
    private MinecraftConfig _config;
    public MinecraftConfigBuilder()
    {
        _config = new MinecraftConfig();
    }

    /// <summary>
    /// sets the server port
    /// </summary>
    /// <param name="port">default: 25565</param>
    /// <returns></returns>
    public MinecraftConfigBuilder WithPort(int port)
    {
        _config.Port = port;
        return this;
    }

    /// <summary>
    /// sets how much ram the server is allowed to use
    /// </summary>
    /// <param name="ram"></param>
    /// <returns></returns>
    public MinecraftConfigBuilder WithRam(string ram)
    {
        _config.Ram = ram;
        return this;
    }

    /// <summary>
    /// sets eula=true in the Eula.txt file
    /// </summary>
    /// <returns></returns>
    public MinecraftConfigBuilder AcceptEula()
    {
        _config.Eula = true;
        return this;
    }

    public MinecraftConfigBuilder WithCurseforgeModpack(string url, string apiKey)
    {
        _config.Modpack = new CurseforgeModpack(url, apiKey);
        _config.InstanceType = InstanceType.CurseforgeModpack;
        return this;
    }

    /// <summary>
    /// https://github.com/itzg/docker-minecraft-server/blob/master/docs/types-and-platforms/mod-platforms/modrinth-modpacks.md
    /// </summary>
    /// <param name="source"> mrpack url, modpack slug, project id, local path to mrpack file </param>
    /// <returns></returns>
    public MinecraftConfigBuilder WithModrinthModpack(string source)
    {
        _config.Modpack = new ModrinthModpack(source);
        _config.InstanceType = InstanceType.ModrinthModpack;
        return this;
    }

    public MinecraftConfigBuilder WithEnv(string name, string value)
    {
        _config.EnvironmentVariables[name] = value;
        return this;
    }

    public MinecraftConfigBuilder WithDifficulty(string difficulty)
    {
        _config.Difficulty = difficulty;
        return this;
    }

    public MinecraftConfigBuilder WithIcon(string url)
    {
        _config.Icon = url;
        return this;
    }
    
    public MinecraftConfigBuilder WithMotd(string motd)
    {
        _config.Motd = motd;
        return this;
    }

    public MinecraftConfig Build()
    {
        return _config;
    }
}