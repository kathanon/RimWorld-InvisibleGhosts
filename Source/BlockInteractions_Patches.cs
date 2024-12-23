using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using Verse;

namespace InvisibleGhosts;
[HarmonyPatch]
public static class BlockTools_Patch {
    public static IEnumerable<MethodBase> TargetMethods() =>
       Util.Methods(nameof(Designator.CanDesignateThing), [typeof(Thing)], typeof(Designator_Cancel));

    [HarmonyPostfix]
    public static AcceptanceReport CanDesignateThing(AcceptanceReport res, Thing t) =>
        res && (!Options.Hide(t) || Options.Tools);
}

[HarmonyPatch]
public static class BlockSelection_Patch {

    [HarmonyPatch(typeof(ThingSelectionUtility), nameof(ThingSelectionUtility.SelectableByMapClick))]
    [HarmonyPostfix]
    public static bool SelectableByMapClick(bool res, Thing t) =>
        res && (!Options.Hide(t) || Options.Selectable);
}
