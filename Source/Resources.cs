using UnityEngine;
using Verse;

namespace InvisibleGhosts;

[StaticConstructorOnStartup]
public class Resources {
    public static Texture2D Ghost = ContentFinder<Texture2D>.Get(Strings.GhostTexturePath);
}
