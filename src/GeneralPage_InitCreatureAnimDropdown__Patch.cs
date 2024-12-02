using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;

namespace QM_SpeedToggle
{
    /// <summary>
    /// Used to prevent the speed hack from affecting the game's default speed.
    /// </summary>
    [HarmonyPatch(typeof(GeneralPage), nameof(GeneralPage.InitCreatureAnimDropdown))]
    public static class GeneralPage_InitCreatureAnimDropdown__Patch
    {
        public static void Prefix()
        {
            GameSettings_CreatureAnimationSpeed__Patch.Disable = true;
        }

        public static void Postfix()
        {
            GameSettings_CreatureAnimationSpeed__Patch.Disable = false;
        }

    }
}
