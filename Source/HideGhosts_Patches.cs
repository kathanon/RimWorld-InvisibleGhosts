using HarmonyLib;
using RimWorld;
using Verse;

namespace InvisibleGhosts;

[HarmonyPatch]
public static class HideGhosts_Patches {
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Thing), "DrawAt")]
    public static bool DrawAt(Thing __instance) 
        => !Options.Hide(__instance);


    [HarmonyPrefix]
    [HarmonyPatch(typeof(SectionLayer_ThingsGeneral), "TakePrintFrom")]
    public static bool TakePrintFrom(Thing t) 
        => !Options.Hide(t);


    private static bool placingMode = false;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(Sketch), nameof(Sketch.DrawGhost))]
    public static void Sketch_DrawGhost(bool placingMode) 
        => HideGhosts_Patches.placingMode = placingMode;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(SketchThing), nameof(SketchThing.DrawGhost))]
    public static bool SketchThing_DrawGhost() 
        => placingMode || Main.Visible || Options.OnlyFloors;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(SketchTerrain), nameof(SketchTerrain.DrawGhost))]
    public static bool SketchTerrain_DrawGhost() 
        => placingMode || Main.Visible;


    [HarmonyPrefix]
    [HarmonyPatch(typeof(OverlayDrawer), "RenderForbiddenOverlay")]
    public static bool RenderForbiddenOverlay(Thing t) 
        => !Options.Hide(t);


    [HarmonyPrefix]
    [HarmonyPatch(typeof(OverlayDrawer), "RenderForbiddenBigOverlay")]
    public static bool RenderForbiddenBigOverlay(Thing t) 
        => !Options.Hide(t);
}
