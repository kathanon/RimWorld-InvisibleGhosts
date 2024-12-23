using Verse;

namespace InvisibleGhosts;

[StaticConstructorOnStartup]
public static class Strings {
    // Non-translated constants
    public const string ID = "kathanon.InvisibleGhosts";
    public const string Name = "Hide Blueprints";

    // Toggle
    public static readonly string GhostTip = (ID + ".Ghost.tip").Translate();

    // Settings
    public static readonly string ShowPlace_title     = (ID + ".ShowPlace.title"    ).Translate();
    public static readonly string ShowPlace_desc      = (ID + ".ShowPlace.desc"     ).Translate();
    public static readonly string ShowArchitect_title = (ID + ".ShowArchitect.title").Translate();
    public static readonly string ShowArchitect_desc  = (ID + ".ShowArchitect.desc" ).Translate();
    public static readonly string Selectable_title    = (ID + ".Selectable.title"   ).Translate();
    public static readonly string Selectable_desc     = (ID + ".Selectable.desc"    ).Translate();
    public static readonly string Tools_title         = (ID + ".Tools.title"        ).Translate();
    public static readonly string Tools_desc          = (ID + ".Tools.desc"         ).Translate();
    public static readonly string OnlyFloors_title    = (ID + ".OnlyFloors.title"   ).Translate();
    public static readonly string OnlyFloors_desc     = (ID + ".OnlyFloors.desc"    ).Translate();

    // Resources
    public static readonly string GhostTexturePath = ID + "/Ghost";
}
