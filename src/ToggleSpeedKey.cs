using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QM_SpeedToggle
{
    /// <summary>
    /// Handles the speed key toggle detection since the Input check
    /// must be an update handler.
    /// </summary>
    internal class ToggleSpeedKey : MonoBehaviour
    {
        public static GameObject _gameObject;
        public static bool ToggledOn = false;
        public static KeyCode Key;

        public void Update()
        {
            if (Input.GetKeyDown(Key))
            {
                ToggledOn = !ToggledOn;
            }
        }

        public static void Init()
        {
            _gameObject = new GameObject("speed_toggle_update");
            _gameObject.AddComponent<ToggleSpeedKey>();
        }

    }
}
