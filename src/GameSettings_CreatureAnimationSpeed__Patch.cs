using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        public static SpeedActivationMode Mode = SpeedActivationMode.Toggle;

        public static void Postfix(ref CreatureAnimationSpeed __result)
        {
             if (Plugin.ToggleSpeedUtil.Disable) return;

            //This sets the Fake Speed enum.  This is used for other patches
            //  to bypass switch statements so the fake speed will be used instead.

            Plugin.ToggleSpeedUtil.SpeedUpIsEngaged = false;

            if (Mode == SpeedActivationMode.Toggle)
            {
                if (ToggleSpeedKey.ToggledOn)
                {
                    Plugin.ToggleSpeedUtil.SpeedUpIsEngaged = true;
                    __result = ToggleSpeedUtil.FakeCreatureAnimationSpeed;
                }
            }
            else
            {
                //Assume hold, which is the only other option currently.
                if(Input.GetKey(ToggleSpeedKey.Key))
                {
                    Plugin.ToggleSpeedUtil.SpeedUpIsEngaged = true;
                    __result = ToggleSpeedUtil.FakeCreatureAnimationSpeed;
                }
            }
        }
    }
}
