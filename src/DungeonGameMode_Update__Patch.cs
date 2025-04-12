using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
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


            //Original IL:
            //IL_0117: ldarg.0
            //IL_0118: ldfld class MGSC.State MGSC.DungeonGameMode::_state
            //IL_011d: callvirt instance !!0 MGSC.State::Get<class MGSC.PlayerCommandQueue>()
            //IL_0122: stloc.s 6
            //// if (Input.anyKeyDown && player.CreatureData.Health.Alive && player.Creature3dView.MoveToPosInProgress)
            //IL_0124: call bool [UnityEngine.InputLegacyModule]UnityEngine.Input::get_anyKeyDown()
            //IL_0129: brfalse.s IL_0152

            //-----new code start -----
            //call IsSpeedKey here
            //IL_0385: brtrue IL_0152
            //-----new code end -----

	        //IL_012b: ldloc.0
	        //IL_012c: ldfld class MGSC.CreatureData MGSC.Creature::CreatureData
	        //IL_0131: ldfld class MGSC.HealthInfo MGSC.CreatureData::Health
            
            Label? ifBranchLabel = null;

            List<CodeInstruction> newInstructions = new CodeMatcher(original)
                .MatchEndForward(
                    CodeMatch.IsLdarg(),
                    CodeMatch.LoadsField(AccessTools.Field(typeof(DungeonGameMode), nameof(DungeonGameMode._state))),
                    CodeMatch.Calls(() => new State().Get<PlayerCommandQueue>()),
                    new CodeMatch(OpCodes.Stloc_S), 
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
                //Just a precaution
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
