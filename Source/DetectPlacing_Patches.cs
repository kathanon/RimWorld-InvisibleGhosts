using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;

namespace InvisibleGhosts {
    [HarmonyPatch]
    public static class DetectStartPlacing_Patch {
        public static IEnumerable<MethodBase> TargetMethods() =>
            Util.Methods(nameof(Designator.Selected), typeof(Designator), typeof(Designator_Place));

        [HarmonyPrefix]
        public static void Selected(Designator __instance) {
            if (__instance is Designator_Place) {
                Main.Placing = true;
            }
        }
    }

    [HarmonyPatch]
    public static class DetectStopPlacing_Patch {
        public static IEnumerable<MethodBase> TargetMethods() =>
            Util.Methods(nameof(Designator.Deselected), typeof(Designator), typeof(Designator_Build));

        [HarmonyPrefix]
        public static void Deselected(Designator __instance) {
            if (__instance is Designator_Place) {
                Main.Placing = false;
            }
        }
    }
}
