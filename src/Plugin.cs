using HarmonyLib;
using MGSC;
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

        public static ToggleSpeedUtil ToggleSpeedUtil { get; private set; }

        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            Directory.CreateDirectory(ConfigDirectories.AllModsConfigFolder);
            ConfigDirectories.UpgradeModDirectory();
            Directory.CreateDirectory(ConfigDirectories.ModPersistenceFolder);
            Config = ModConfig.LoadConfig(ConfigDirectories.ConfigPath);

            ToggleSpeedUtil = new ToggleSpeedUtil(Config.SpeedMultiplier);

            ToggleSpeedKey.Init();
            ToggleSpeedKey.Key = Config.ToggleKey;

            GameSettings_CreatureAnimationSpeed__Patch.Mode = Config.ActivationMode;

            new Harmony("NBKRedSpy_" + ConfigDirectories.ModAssemblyName).PatchAll();
        }

     
    }
}
