﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace QM_SpeedToggle
{
    public class ModConfig
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public KeyCode ToggleKey = KeyCode.CapsLock;

        [JsonConverter(typeof(StringEnumConverter))]
        public CreatureAnimationSpeed AnimationSpeed = CreatureAnimationSpeed.X8;

        [JsonConverter(typeof(StringEnumConverter))]
        public SpeedActivationMode ActivationMode = SpeedActivationMode.Toggle;

        /// <summary>
        /// If true, will not count the Speed Key as a key that will stop
        /// movement.  Allows the user to toggle in and out of speed mode without stopping
        /// </summary>
        public bool DoNotStopOnSpeedKeyDown { get; set; } = true;


        /// <summary>
        /// Loads the configuration
        /// </summary>
        /// <param name="configPath">The full path to the config file.</param>
        /// <returns></returns>
        public static ModConfig LoadConfig(string configPath)
        {
            ModConfig config;

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            if (File.Exists(configPath))
            {
                try
                {
                    string sourceJson = File.ReadAllText(configPath);

                    config = JsonConvert.DeserializeObject<ModConfig>(sourceJson, serializerSettings);

                    //Add any new elements that have been added since the last mod version the user had.
                    string upgradeConfig = JsonConvert.SerializeObject(config, serializerSettings);

                    if (upgradeConfig != sourceJson)
                    {
                        Debug.Log("Updating config with missing elements");
                        //re-write
                        File.WriteAllText(configPath, upgradeConfig);
                    }

                    return config;
                }
                catch (Exception ex)
                {
                    Debug.LogError("Error parsing configuration.  Ignoring config file and using defaults");
                    Debug.LogException(ex);

                    //Not overwriting in case the user just made a typo.
                    config = new ModConfig();
                    return config;
                }
            }
            else
            {
                config = new ModConfig();
                
                string json = JsonConvert.SerializeObject(config, serializerSettings);
                File.WriteAllText(configPath, json);

                return config;
            }


        }
    }
}
