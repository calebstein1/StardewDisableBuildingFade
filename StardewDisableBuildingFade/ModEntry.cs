using HarmonyLib;
using StardewModdingAPI;
using StardewValley.Buildings;
using StardewValley.GameData.Buildings;

namespace StardewDisableBuildingFade;

internal sealed class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        var harmony = new Harmony(ModManifest.UniqueID);
        
        harmony.Patch(
            original: AccessTools.Method(typeof(Building), "UpdateTransparency"),
            prefix: new HarmonyMethod(typeof(ModEntry), nameof(DisableFadePrefix))
        );
    }

    private static bool DisableFadePrefix()
    {
        return false;
    }
}