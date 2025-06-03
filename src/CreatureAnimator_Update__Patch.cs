using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using Newtonsoft.Json.Serialization;
using MGSC;

namespace QM_SpeedToggle
{
    [HarmonyPatch(typeof(MGSC.CreatureAnimator), nameof(CreatureAnimator.Update))]
    public static class CreatureAnimator_Update__Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            //Set the default value for the local value 0 so if the switch falls through due to 
            //the fake speed enum, it will use this default.

            List<CodeInstruction> originalInstructions = instructions.ToList();

            var newInstructions = new CodeMatcher(originalInstructions)
                .MatchEndForward(
                    new CodeMatch(OpCodes.Call, AccessTools.PropertyGetter(typeof(UnityEngine.Time), nameof(UnityEngine.Time.deltaTime))),
                    new CodeMatch(OpCodes.Stloc_0)
                 )
                .ThrowIfNotMatch("Could not find the delta time set")
                .Advance(1)
                .Insert(
                    new CodeInstruction(OpCodes.Ldloc_0),
                    CodeInstruction.Call(() => GetTimeMultiplier()),
                    new CodeInstruction(OpCodes.Mul),
                    new CodeInstruction(OpCodes.Stloc_0)
                    )
                .InstructionEnumeration()
                .ToList();

            return newInstructions;
        }

        public static float GetTimeMultiplier()
        {
            return Plugin.ToggleSpeedUtil.IsEnbledAndEngaged ? Plugin.ToggleSpeedUtil.Multiplier : 1;
        }
    }
}
