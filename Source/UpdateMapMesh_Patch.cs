using HarmonyLib;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace InvisibleGhosts
{
    [HarmonyPatch]
    public static class UpdateMapMesh_Patch
    {
        private static readonly Dictionary<Map,bool> prevUpdate = new Dictionary<Map,bool>();

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Map), nameof(Map.MapUpdate))]
        public static void UpdateMap(Map __instance)
        {
            Map map = __instance;
            if (WorldRendererUtility.WorldRenderedNow || Find.CurrentMap != map) return;

            if (prevUpdate.TryGetValue(map, out bool prev) && prev != Main.Visible)
            {
                map.mapDrawer.WholeMapChanged(MapMeshFlag.Things | MapMeshFlag.Buildings);
            }

            prevUpdate[map] = Main.Visible;
        }
    }
}
