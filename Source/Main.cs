using HarmonyLib;
using RimWorld;
using RimWorld.SketchGen;
using Verse;

namespace InvisibleGhosts
{
    public class Main : HugsLib.ModBase {
        public override string ModIdentifier => Strings.MOD_IDENTIFIER;

        public static bool Visible => 
            ShowGhosts || 
            (Placing && Options.ShowPlace) || 
            (InArchitect && Options.ShowArchitect);

        public static bool ShowGhosts  = true;
        public static bool Placing     = false;

        public static bool InArchitect => Find.MainTabsRoot.OpenTab?.defName == "Architect";

        public override void DefsLoaded() {
            Options.Setup(Settings);
        }
    }
}
