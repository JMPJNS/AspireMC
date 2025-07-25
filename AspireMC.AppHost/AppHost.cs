using AspireMC;
using AspireMC.Config;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddMinecraft("test-server", new MinecraftConfigBuilder()
    .WithPort(25568)
    .WithRam("8G")
    .WithModrinthModpack("fabulously-optimized")
    .AcceptEula()
    .Build()
);

builder.Build().Run();