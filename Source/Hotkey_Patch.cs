using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace InvisibleGhosts
{
    [DefOf]
    public static class MyKeyBindings
    {
        public static KeyBindingDef kathanon_ToggleGhosts;
    }

    [HarmonyPatch(typeof(UIRoot))]
    public static class Hotkey_Patch
    {
		[HarmonyPostfix]
		[HarmonyPatch(nameof(UIRoot.UIRootOnGUI))]
		public static void OnGUI()
		{
            if (Current.ProgramState == ProgramState.Playing &&
                Find.CurrentMap != null &&
                !WorldRendererUtility.WorldRenderedNow &&
                Event.current.type == EventType.KeyDown &&
                Event.current.keyCode != KeyCode.None &&
                MyKeyBindings.kathanon_ToggleGhosts.JustPressed)
            {
                Log.Warning($"  Toggle ghosts (keycode {Event.current.keyCode})");
                Main.ShowGhosts = !Main.ShowGhosts;
            }
        }

        public static bool Test()
        {
            String FilePath = "";
            String BeforeLine = "";
            String InsertLine = "";

            if (File.Exists(FilePath))
            {
                bool lookInsert = true, lookBefore = true;
                String insert = InsertLine.Trim(), before = BeforeLine.Trim();
                List<String> lines = new List<String>();
                foreach (String line in File.ReadAllLines(FilePath))
                {
                    if (lookBefore) { 
                        if (lookInsert && line.Trim() == insert) {
                            lookInsert = false;
                        } else if (line.Trim() == before) {
                            if (lookInsert) lines.Add(InsertLine);
                            lookBefore = false;
                        }
                    }
                    lines.Add(line);
                }
                if (!lookBefore && lookInsert) File.WriteAllLines(FilePath, lines);
            }
            return true;
        }
    }
}
