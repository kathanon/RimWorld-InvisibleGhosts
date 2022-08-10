using HugsLib.Settings;
using System;

namespace InvisibleGhosts {
    public static class Options {
        public static SettingHandle<bool> ShowPlace { get; private set; }
        public static SettingHandle<bool> ShowArchitect { get; private set; }
        public static SettingHandle<bool> Selectable { get; private set; }
        public static SettingHandle<bool> Tools { get; private set; }

        public static void Setup(ModSettingsPack settings) {
            ShowPlace     = settings.GetHandle("showPlace",     Strings.ShowPlace_title,     Strings.ShowPlace_desc,     true);
            ShowArchitect = settings.GetHandle("showArchitect", Strings.ShowArchitect_title, Strings.ShowArchitect_desc, false);
            Selectable    = settings.GetHandle("selectable",    Strings.Selectable_title,    Strings.Selectable_desc,    false);
            Tools         = settings.GetHandle("tools",         Strings.Tools_title,         Strings.Tools_desc,         false);
        }
    }
}