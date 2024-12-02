using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QM_SpeedToggle
{

    /// <summary>
    /// Toggles the animation speed for the game.
    /// </summary>
    [HarmonyPatch(typeof(GameSettings), nameof(GameSettings.CreatureAnimationSpeed), MethodType.Getter)]
    public static class GameSettings_CreatureAnimationSpeed__Patch
    {

        public static CreatureAnimationSpeed Speed = CreatureAnimationSpeed.X8;
        public static SpeedActivationMode Mode = SpeedActivationMode.Toggle;

        /// <summary>
        /// Used to temporarily disable the speed change.  For instance, to prevent the hack
        /// from affecting the game settings page.
        /// </summary>
        public static bool Disable = false;

        public static void Postfix(ref CreatureAnimationSpeed __result)
        {
            if (Disable) return;

            if(Mode == SpeedActivationMode.Toggle)
            {
                if (ToggleSpeedKey.ToggledOn)
                {
                    __result = Speed;
                }
            }
            else
            {
                //Assume hold, which is the only other option currently.
                if(Input.GetKey(ToggleSpeedKey.Key))
                {
                    __result = Speed;
                }
            }
        }
    }
}
