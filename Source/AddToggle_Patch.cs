using HarmonyLib;
using RimWorld;
using Verse;

namespace InvisibleGhosts;

[HarmonyPatch(typeof(PlaySettings), "DoPlaySettingsGlobalControls")]
public static class AddToggle_Patch {
    [HarmonyPostfix]
    public static void AddToggle(WidgetRow row, bool worldView) {
        if (worldView)
            return;

        if (row == null || Resources.Ghost == null)
            return;

        row.ToggleableIcon(ref Main.ShowGhosts, Resources.Ghost,
            Strings.GhostTip, SoundDefOf.Mouseover_ButtonToggle);
    }
}
