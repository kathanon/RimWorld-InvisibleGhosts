using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace InvisibleGhosts
{
    [StaticConstructorOnStartup]
    public class Resources
    {
        public static Texture2D Ghost = ContentFinder<Texture2D>.Get(Strings.GhostTexturePath);
    }
}
