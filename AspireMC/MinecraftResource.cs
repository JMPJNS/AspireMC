// For ease of discovery, resource types should be placed in
// the Aspire.Hosting.ApplicationModel namespace. If there is
// likelihood of a conflict on the resource name consider using
// an alternative namespace.

using Aspire.Hosting.ApplicationModel;
using AspireMC.Config;

namespace AspireMC;

public sealed class MinecraftResource(string name, MinecraftConfig config) : ContainerResource(name)
{

}