using MelonLoader;
using System.Reflection;

//This is a C# comment. Comments have no impact on compilation.

[assembly: AssemblyTitle(ToolsQuality.BuildInfo.ModName)]
[assembly: AssemblyCopyright($"Created by " + ToolsQuality.BuildInfo.ModAuthor)]

[assembly: AssemblyVersion(ToolsQuality.BuildInfo.ModVersion)]
[assembly: AssemblyFileVersion(ToolsQuality.BuildInfo.ModVersion)]
[assembly: MelonInfo(typeof(ToolsQuality.ToolsQuality), ToolsQuality.BuildInfo.ModName, ToolsQuality.BuildInfo.ModVersion, ToolsQuality.BuildInfo.ModAuthor)]

//This tells MelonLoader that the mod is only for The Long Dark.
[assembly: MelonGame("Hinterland", "TheLongDark")]