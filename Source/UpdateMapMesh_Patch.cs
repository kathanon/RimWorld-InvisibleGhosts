using HarmonyLib;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

#if VERSION_1_5
using MapMeshFlag = RimWorld.MapMeshFlagDefOf;
#endif

namespace InvisibleGhosts; 
[HarmonyPatch]
public static class UpdateMapMesh_Patch {
    private static readonly Dictionary<Map,bool> prevUpdate = [];

    [HarmonyPrefix]
    [HarmonyPatch(typeof(Map), nameof(Map.MapUpdate))]
    public static void UpdateMap(Map __instance) {
        Map map = __instance;
        if (WorldRendererUtility.WorldRenderedNow || Find.CurrentMap != map) return;

        if (prevUpdate.TryGetValue(map, out bool prev) && prev != Main.Visible) {
            map.mapDrawer.WholeMapChanged(MapMeshFlag.Things | MapMeshFlag.Buildings);
        }

        prevUpdate[map] = Main.Visible;
    }
}
