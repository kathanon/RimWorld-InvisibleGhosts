using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace InvisibleGhosts;

[DefOf]
public static class MyKeyBindings {
    public static KeyBindingDef kathanon_ToggleGhosts;
}

[HarmonyPatch(typeof(UIRoot))]
public static class Hotkey_Patch {
    [HarmonyPostfix]
    [HarmonyPatch(nameof(UIRoot.UIRootOnGUI))]
    public static void OnGUI() {
        if (Current.ProgramState == ProgramState.Playing
                && Find.CurrentMap != null
                && !WorldRendererUtility.WorldRenderedNow
                && Event.current.type == EventType.KeyDown
                && Event.current.keyCode != KeyCode.None
                && MyKeyBindings.kathanon_ToggleGhosts.JustPressed) {
            Main.ShowGhosts = !Main.ShowGhosts;
        }
    }
}
