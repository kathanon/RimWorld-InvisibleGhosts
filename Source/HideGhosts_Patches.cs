using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace InvisibleGhosts
{
    [HarmonyPatch]
    public static class HideGhosts_Patches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Thing), nameof(Thing.DrawAt))]
        public static bool DrawAt(Thing __instance) => Visible(__instance);

        [HarmonyPrefix]
        [HarmonyPatch(typeof(SectionLayer_ThingsGeneral), "TakePrintFrom")]
        public static bool TakePrintFrom(Thing t) => Visible(t);

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Sketch), nameof(Sketch.DrawGhost))]
        public static bool DrawSketchGhost(bool placingMode) => placingMode || Main.Visible;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(OverlayDrawer), "RenderForbiddenOverlay")]
        public static bool RenderForbiddenOverlay(Thing t) => Visible(t);

        [HarmonyPrefix]
        [HarmonyPatch(typeof(OverlayDrawer), "RenderForbiddenBigOverlay")]
        public static bool RenderForbiddenBigOverlay(Thing t) => Visible(t);

        private static bool Visible(Thing thing) => Main.Visible || !thing.def.IsBlueprint;
    }
}
