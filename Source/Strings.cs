using System.Collections.Generic;
using Verse;

namespace InvisibleGhosts
{
    internal static class Strings
    {
        // Non-translated constants
        public const string MOD_IDENTIFIER = "kathanon.InvisibleGhosts";
        public const string PREFIX = MOD_IDENTIFIER + ".";

        // Toggle
        public static readonly string GhostTip = (PREFIX + "Ghost.tip").Translate();

        // Settings
        public static readonly string ShowPlace_title     = (PREFIX + "ShowPlace.title"    ).Translate();
        public static readonly string ShowPlace_desc      = (PREFIX + "ShowPlace.desc"     ).Translate();
        public static readonly string ShowArchitect_title = (PREFIX + "ShowArchitect.title").Translate();
        public static readonly string ShowArchitect_desc  = (PREFIX + "ShowArchitect.desc" ).Translate();
        public static readonly string Selectable_title    = (PREFIX + "Selectable.title"   ).Translate();
        public static readonly string Selectable_desc     = (PREFIX + "Selectable.desc"    ).Translate();
        public static readonly string Tools_title         = (PREFIX + "Tools.title"        ).Translate();
        public static readonly string Tools_desc          = (PREFIX + "Tools.desc"         ).Translate();


        // Resources
        public static readonly string GhostTexturePath = MOD_IDENTIFIER + "/Ghost";
    }
}
