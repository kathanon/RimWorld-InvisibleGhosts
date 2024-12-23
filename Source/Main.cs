using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace InvisibleGhosts;

[StaticConstructorOnStartup]
public class Main : Mod {
     public static bool Visible => 
        ShowGhosts || 
        (Placing && Options.ShowPlace) || 
        (InArchitect && Options.ShowArchitect);

    public static bool ShowGhosts  = true;
    public static bool Placing     = false;

    public static bool InArchitect 
        => Find.MainTabsRoot.OpenTab?.defName == "Architect";

   public static Main Instance { get; private set; }

    static Main() {
        var harmony = new Harmony(Strings.ID);
        harmony.PatchAll();
    }

    public Main(ModContentPack content) : base(content) {
        Instance = this;
    }
    
    public static void OnInit() {
		Instance.Settings();
	}
    
    public Options Settings() 
		=> GetSettings<Options>();

    public override void DoSettingsWindowContents(Rect inRect) 
        => Settings().DoGUI(inRect);

    public override string SettingsCategory() 
        => Strings.Name;
}

[HarmonyPatch]
public static class InitHook {
    [HarmonyPatch(typeof(MainMenuDrawer), nameof(MainMenuDrawer.Init))]
    [HarmonyPostfix]
    public static void Init() 
        => Main.OnInit();
}
