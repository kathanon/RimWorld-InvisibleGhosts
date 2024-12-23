using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace InvisibleGhosts;
public static class Util {
    private static readonly Type[] NO_TYPES = [];

    public static IEnumerable<MethodBase> Methods(string name, Type[] args, params Type[] types) {
        foreach (var type in types) {
            yield return AccessTools.Method(type, name, args);
        }
    }

    public static IEnumerable<MethodBase> Methods(string name, params Type[] types) =>
        Methods(name, NO_TYPES, types);
}
