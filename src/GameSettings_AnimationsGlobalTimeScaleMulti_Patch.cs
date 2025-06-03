using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace QM_SpeedToggle
{
    /// <summary>
    /// This is the common function which handles nearly all of the game speed time deltas
    /// Changes the return to the computed custom speed.
    /// </summary>
    [HarmonyPatch(typeof(GameSettings), nameof(GameSettings.AnimationsGlobalTimeScaleMult))]
    internal static class GameSettings_AnimationsGlobalTimeScaleMulti_Patch
    {
        public static bool Prefix(ref float __result)
        {
            if (!Plugin.ToggleSpeedUtil.IsEnbledAndEngaged) return true;

            __result = Plugin.ToggleSpeedUtil.TimeScale;
            
            return false;
        }
    }
}
