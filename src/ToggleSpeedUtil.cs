using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM_SpeedToggle
{
    public class ToggleSpeedUtil
    {

        /// <summary>
        /// Used to temporarily disable the speed change.  For instance, to prevent the hack
        /// from affecting the game settings page.
        /// </summary>
        public bool Disable = false;

        public const CreatureAnimationSpeed FakeCreatureAnimationSpeed = (CreatureAnimationSpeed)99_999;

        /// <summary>
        /// True if the speed toggle is engaged.
        /// </summary>
        public bool SpeedUpIsEngaged = false;

        /// <summary>
        /// True if engaged and is not being force disabled.
        /// </summary>
        public bool IsEnbledAndEngaged => !Disable && SpeedUpIsEngaged;

        public float Multiplier { get; set; }

        public float TimeScale { get; private set; }

        public ToggleSpeedUtil(float multiplier)
        {
            TimeScale = 1f / multiplier;
            Multiplier = multiplier;
        }

    }
}
