using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using Newtonsoft.Json.Serialization;
using MGSC;
using System.CodeDom;

namespace QM_SpeedToggle
{
    /// <summary>
    /// Changes MeleeAttackAnimation.Process's switch statement to include the speed multiplier.
    /// MeleeAttackAnimation.Process looks to have not been changed to the common function
    /// that everywhere uses to get the multiplier.
    /// </summary>
    [HarmonyPatch(typeof(MGSC.MeleeAttackAnimation), nameof(MeleeAttackAnimation.Process))]
    public static class MeleeAttackAnimation_Process_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            //The base game sets the default multiplier to zero, and then changes it based on the switch statement.
            //  Change it to the mod's speed multiplier so if the speed is set to the fake speed enum,
            //  the switch will fall through and keep the default.

            List<CodeInstruction> originalInstructions = instructions.ToList();

            List<CodeInstruction> newInstructions = new CodeMatcher(originalInstructions)
                .MatchStartForward(
                    new CodeMatch(OpCodes.Ldc_R4),
                    new CodeMatch(OpCodes.Stloc_0)
                 )
                .ThrowIfNotMatch("Could not find the default value set")
                //Remove the default value
                .RemoveInstruction()
                .Insert(
                    CodeInstruction.Call(() => GetMultiplier())
                )
                .InstructionEnumeration()
                .ToList();

            return newInstructions;
        }

        public static float GetMultiplier() 
        {
            return Plugin.ToggleSpeedUtil.Multiplier;
        }
    }
}
