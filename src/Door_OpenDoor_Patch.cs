using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace QM_SpeedToggle
{
    /// <summary>
    /// Disables the pause when opening doors.  Greatly speeds up moving across the level.
    /// </summary>
    [HarmonyPatch(typeof(PlayerInteractionSystem), nameof(PlayerInteractionSystem.OpenTheDoor))]
    internal static class PlayerInteractionSystem_OpenTheDoor_Patch
    {
        public static bool Prefix(Creatures creatures, Scenarios scenarios, TurnMetadata turnMetadata, Door door)
        {
            if (Plugin.ToggleSpeedUtil.IsEnbledAndEngaged)
            {

                //WARNING COPY - The RemovePause is a direct copy and replace with the 
                //  game's PlayerInteractionSystem.OpenTheDoor function.
                //There is so little code, it wasn't worth a transpile.
                OriginalRemovePause(creatures, scenarios, turnMetadata, door);
                return false;
            }

            return true;
        }

        /// <summary>
        /// The original version, but removes the pause
        /// </summary>
        /// <param name="creatures"></param>
        /// <param name="scenarios"></param>
        /// <param name="turnMetadata"></param>
        /// <param name="door"></param>
        private static void OriginalRemovePause(Creatures creatures, Scenarios scenarios, TurnMetadata turnMetadata, Door door)
        {
            if (!PlayerInteractionSystem.CanInteractObstacles(creatures, scenarios, door.MapObstacle, out var limitType))
            {
                SingletonMonoBehaviour<TooltipFactory>.Instance.ShowLimitsTooltip(limitType);
                return;
            }

            door.OpenDoor();

            //Remove this original line:
            //turnMetadata.StartPause(door.OpenDoorPauseDuration);

            creatures.Player.CreatureData.EffectsController.PropagateAction(PlayerActionHappened.DoorInteraction);
            PlayerInteractionSystem.EndPlayerTurn(creatures, PlayerEndTurnContext.MapObstacleInteraction);
        }

    }
}



