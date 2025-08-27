using HarmonyLib;
using ModConfigMenu;
using ModConfigMenu.Objects;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

namespace QM_SpeedToggle.Mcm
{
    internal class McmConfiguration : McmConfigurationBase
    {

        public McmConfiguration(ModConfig config) : base (config) { }

        public override void Configure()
        {
            ModConfig defaults = new ModConfig();

            ModConfigMenuAPI.RegisterModConfig("Speed Toggle", new List<ConfigValue>()
            {
                CreateConfigProperty(nameof(ModConfig.DoNotStopOnSpeedKeyDown),
                    "Will not count the Speed Key as a key that will stop movement.  Allows the user to toggle in and out of speed mode without stopping"),
                CreateReadOnly(nameof(ModConfig.ActivationMode)),
                CreateReadOnly(nameof(ModConfig.AnimationSpeed)),
                CreateReadOnly(nameof(ModConfig.ToggleKey)),
                CreateResetMessage(),
            }, OnSave);
        }
         
    }
}
