namespace AspireMC.Config;

public class MinecraftConfig
{
    public int Port { get; set; } = 25565;
    public bool Eula { get; set; } = false;
    public string Ram { get; set; } = "1G";
    /// <summary>
    /// Sets the container tag: https://hub.docker.com/r/itzg/minecraft-server/tags
    /// </summary>
    public string JavaVersion { get; set; } = "latest";
    public InstanceType InstanceType { get; set; } = InstanceType.Vanilla;
    /// <summary>
    /// The version of minecraft to use (e.g. LATEST, SNAPSHOT, 1.21.1)
    /// </summary>
    public string MinecraftVersion { get; set; } = "LATEST";
    public Modpack.IModpack? Modpack { get; set; } = null;
    public Dictionary<string, string> EnvironmentVariables { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// peaceful, easy, normal (default), hard
    /// </summary>
    public string Difficulty { get; set; } = "normal";
    /// <summary>
    /// url to the server icon
    /// </summary>
    public string? Icon { get; set; }

    public string? Motd { get; set; } = "Minecraft Server powered by §5Aspire";
}