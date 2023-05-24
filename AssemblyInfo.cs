using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(Spawner.BuildInfo.Description)]
[assembly: AssemblyDescription(Spawner.BuildInfo.Description)]
[assembly: AssemblyCompany(Spawner.BuildInfo.Company)]
[assembly: AssemblyProduct(Spawner.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + Spawner.BuildInfo.Author)]
[assembly: AssemblyTrademark(Spawner.BuildInfo.Company)]
[assembly: AssemblyVersion(Spawner.BuildInfo.Version)]
[assembly: AssemblyFileVersion(Spawner.BuildInfo.Version)]
[assembly: MelonInfo(typeof(Spawner.Spawner), Spawner.BuildInfo.Name, Spawner.BuildInfo.Version, Spawner.BuildInfo.Author, Spawner.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]