using RimWorld;
using System.Linq;
using UnityEngine;
using Verse;

namespace InvisibleGhosts; 
public class Options : ModSettings {
    public static bool ShowPlace     => inst[0];
    public static bool ShowArchitect => inst[1];
    public static bool Selectable    => inst[2];
    public static bool Tools         => inst[3];
    public static bool OnlyFloors    => inst[4];

    private static Options inst;

    public static bool Hide(Thing thing) 
        => !Main.Visible 
        && thing.def.IsBlueprint
        && (!OnlyFloors || thing.def.entityDefToBuild.designationCategory == DesignationCategoryDefOf.Floors);

    private readonly Option[] options = [
        new("showPlace",     Strings.ShowPlace_title,     Strings.ShowPlace_desc,     true ),
        new("showArchitect", Strings.ShowArchitect_title, Strings.ShowArchitect_desc, false),
        new("selectable",    Strings.Selectable_title,    Strings.Selectable_desc,    false),
        new("tools",         Strings.Tools_title,         Strings.Tools_desc,         false),
        new("onlyFloors",    Strings.OnlyFloors_title,    Strings.OnlyFloors_desc,    false),
    ];

    public Options() {
        inst = this;
    }

    private bool this[int i] => options[i].value;

    public void DoGUI(Rect r) {
        r.width = Mathf.Min(r.width, options.Max(x => x.Width));
        r.height = Widgets.CheckboxSize;
        foreach (var option in options) {
            option.DoGUI(ref r);
        }
    }

    public override void ExposeData() {
        foreach (var option in options) {
            option.ExposeData();
        }
    }

    private class Option(string name, string label, string description, bool def) {
        private readonly string name = name;
        private readonly string label = label;
        private readonly string description = description;
        private readonly bool def = def;
        private float? width;
        public bool value = def;

        public float Width 
            => width ??= Text.CalcSize(label).x + 8f + Widgets.CheckboxSize;

        public void DoGUI(ref Rect r) {
            TooltipHandler.TipRegion(r, description);
            Widgets.CheckboxLabeled(r, label, ref value);
            r.y += r.height + 4f;
        }

        public void ExposeData() {
            Scribe_Values.Look(ref value, name, def);
        }
    }
}