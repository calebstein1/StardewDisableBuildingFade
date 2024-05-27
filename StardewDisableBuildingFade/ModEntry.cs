using HarmonyLib;
using StardewModdingAPI;

namespace StardewDisableBuildingFade;

internal sealed class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        var harmony = new Harmony(ModManifest.UniqueID);
        
        harmony.Patch(
            original: AccessTools.Constructor(typeof(StardewValley.GameData.Buildings.BuildingData)),
            postfix: new HarmonyMethod(typeof(ModEntry), nameof(DisableFadePrefix))
        );
    }

    private void DisableFadePrefix()
    {
        
    }
}