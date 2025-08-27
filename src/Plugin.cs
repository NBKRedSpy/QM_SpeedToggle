using HarmonyLib;
using MGSC;
using QM_SpeedToggle.Mcm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QM_SpeedToggle
{
    public static class Plugin
    {
        public static ConfigDirectories ConfigDirectories = new ConfigDirectories();
        public static ModConfig Config { get; private set; }

        private static McmConfiguration McmConfiguration { get; set; }

        public static Logger Logger { get; } = new Logger();


        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            Directory.CreateDirectory(ConfigDirectories.AllModsConfigFolder);
            ConfigDirectories.UpgradeModDirectory();
            Directory.CreateDirectory(ConfigDirectories.ModPersistenceFolder);
            Config = ModConfig.LoadConfig(ConfigDirectories.ConfigPath);

            ToggleSpeedKey.Init();
            ToggleSpeedKey.Key = Config.ToggleKey;

            GameSettings_CreatureAnimationSpeed__Patch.Speed = Config.AnimationSpeed;
            GameSettings_CreatureAnimationSpeed__Patch.Mode = Config.ActivationMode;

            McmConfiguration = new McmConfiguration(Config);
            McmConfiguration.TryConfigure();

            new Harmony("NBKRedSpy_" + ConfigDirectories.ModAssemblyName).PatchAll();
        }

     
    }
}
