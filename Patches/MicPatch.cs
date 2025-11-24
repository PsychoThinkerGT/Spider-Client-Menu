using System;
using HarmonyLib;

namespace StupidTemplate.Patches
{
    [HarmonyPatch(typeof(GorillaSpeakerLoudness), "UpdateLoudness")]
    public class MicPatch
    {
        public static bool enabled;

        private static bool Prefix(GorillaSpeakerLoudness __instance, ref bool ___isMicEnabled, ref bool ___isSpeaking, ref float ___loudness) =>
            !enabled || __instance.gameObject.name != "Local Gorilla Player";
    }
}

