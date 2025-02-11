using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static HarmonyLib.Code;

namespace QM_SpeedToggle
{
    [HarmonyPatch(typeof(DungeonGameMode), nameof(DungeonGameMode.Update))]
    public static class DungeonGameMode_Update__Patch
    {

        public static bool Prepare()
        {
            return Plugin.Config.DoNotStopOnSpeedKeyDown;
        }

        /// <summary>
        /// Ignores the Speed Toggle Key when the game checks for a key press.  Normally the game will stop queued movement 
        /// on any key press.  Allows the user to change the speed while moving.
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {

            List<CodeInstruction> original = new List<CodeInstruction>(instructions);

            //Goal:  Add code to ignore the speed toggle key for the "anykey" movement stop check.
            //  else if (Input.anyKeyDown && player.CreatureData.Health.Alive && player.Creature3dView.MoveToPosInProgress)
            //to:
            //  else if (____ IsNotSpeedKey && ____ Input.anyKeyDown && player.CreatureData.Health.Alive && player.Creature3dView.MoveToPosInProgress)


            //IL
            //IL_037f: ret

            //-----new code start -----
            //call IsSpeedKey here
            //IL_0385: brtrue IL_03ae
            //-----new code end -----
            //IL_0380: call bool [UnityEngine.InputLegacyModule]UnityEngine.Input::get_anyKeyDown()
            //IL_0385: brfalse.s IL_03ae

            Label? ifBranchLabel = null;

            List<CodeInstruction> newInstructions = new CodeMatcher(original)
                .MatchEndForward(
                    CodeMatch.IsLdloc(),
                    CodeMatch.Calls(() => new PlayerCommandQueue().Clear()),
                    new CodeMatch(OpCodes.Ret), //Harmony has as a br, but it goes to the end so is the same as ILSpy's ret
                    CodeMatch.Calls(AccessTools.PropertyGetter(typeof(Input), nameof(Input.anyKeyDown))),
                    new CodeMatch((op) => op.Branches(out ifBranchLabel))
                )
                .ThrowIfNotMatch("Unable to find the anyKeyDown")
                .Advance(1)
                //Adding after the anyKeyDown since it avoids needing to update the labels that point to the anyKeyDown
                //  location.
                .InsertAndAdvance(
                    CodeInstruction.Call(typeof(DungeonGameMode_Update__Patch), nameof(DungeonGameMode_Update__Patch.IsSpeedKey)),
                    new CodeInstruction(OpCodes.Brtrue, ifBranchLabel.Value)
                )
                .MatchEndForward(
                    CodeMatch.IsLdloc(),
                    CodeMatch.LoadsField(AccessTools.Field(typeof(Creature), nameof(Creature.CreatureData))),
                    CodeMatch.LoadsField(AccessTools.Field(typeof(CreatureData), nameof(CreatureData.Health)))
                )
                .ThrowIfNotMatch("Did not find Health check")
                .InstructionEnumeration()
                .ToList();
            ;

            return newInstructions;
        }

        public static bool IsSpeedKey()
        {
            return Input.GetKey(Plugin.Config.ToggleKey);
        }
    }
}
