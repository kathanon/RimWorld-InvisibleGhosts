using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace InvisibleGhosts {
    [HarmonyPatch]
    public static class BlockTools_Patch {
        public static IEnumerable<MethodBase> TargetMethods() =>
           Util.Methods(nameof(Designator.CanDesignateThing), new Type[] { typeof(Thing) }, 
               typeof(Designator_Cancel));

        [HarmonyPostfix]
        public static AcceptanceReport CanDesignateThing(AcceptanceReport res, Thing t) =>
            res && (!t.def.IsBlueprint || Options.Tools || Main.Visible);
    }

    [HarmonyPatch]
    public static class BlockSelection_Patch {

        [HarmonyPatch(typeof(ThingSelectionUtility), nameof(ThingSelectionUtility.SelectableByMapClick))]
        [HarmonyPostfix]
        public static bool SelectableByMapClick(bool res, Thing t) =>
            res && (!t.def.IsBlueprint || Options.Selectable || Main.Visible);
    }
}
