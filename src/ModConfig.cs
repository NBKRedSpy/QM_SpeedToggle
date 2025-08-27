using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QM_SpeedToggle.Mcm;
using UnityEngine;

namespace QM_SpeedToggle
{
    public class ModConfig : ISave
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public KeyCode ToggleKey = KeyCode.CapsLock;

        [JsonConverter(typeof(StringEnumConverter))]
        public CreatureAnimationSpeed AnimationSpeed = CreatureAnimationSpeed.X8;

        [JsonConverter(typeof(StringEnumConverter))]
        public SpeedActivationMode ActivationMode = SpeedActivationMode.Hold;

        /// <summary>
        /// If true, will not count the Speed Key as a key that will stop
        /// movement.  Allows the user to toggle in and out of speed mode without stopping
        /// </summary>
        public bool DoNotStopOnSpeedKeyDown { get; set; } = true;

        [JsonIgnore]
        private static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
        };

        [JsonIgnore]
        private static string ConfigPath { get; set; } = Plugin.ConfigDirectories.ConfigPath;


        /// <summary>
        /// Loads the configuration
        /// </summary>
        /// <param name="configPath">The full path to the config file.</param>
        /// <returns></returns>
        public static ModConfig LoadConfig(string configPath)
        {
            ModConfig config;

            ConfigPath = configPath;

            if (File.Exists(configPath))
            {
                try
                {
                    string sourceJson = File.ReadAllText(configPath);

                    config = JsonConvert.DeserializeObject<ModConfig>(sourceJson, SerializerSettings);

                    //Add any new elements that have been added since the last mod version the user had.
                    string upgradeConfig = JsonConvert.SerializeObject(config, SerializerSettings);

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
                config.Save();
                return config;
            }


        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, SerializerSettings);
            File.WriteAllText(ConfigPath, json);
        }


    }
}
