# Quasimorph Speed Toggle

![thumbnail icon](media/thumbnail.png)

Want to move across the map quickly, but don't want to want combat to be at x8 speed all the time?
This mod allows the player to temporarily change the game's "animation speed" to x8 by holding a key.

By default, holding down the Caps Lock key will set the animation speed to x8, and releasing it will return to the game's animation speed setting.

The mod can be configured as follows:
* The key to activate the speed change.
* If the key is held down or toggles the speed change.
* The speed to use.  

See the [Configuration](#configuration) section below.

# Monster Detection
The [Stop on Monster Detection](https://steamcommunity.com/sharedfiles/filedetails/?id=3292592993) mod is recommended.  It prevents monsters that are spotted (the asterisk icon) from ambushing the player.  

# Configuration

The configuration file will be created on the first game run and can be found at `%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\QM_SpeedToggle\config.json`.

|Name|Default|Description|
|--|--|--|
|ToggleKey|CapsLock|The key that will activate the speed change.  See the [Key List](#key-list) section.|
|AnimationSpeed|X8|The speed change to apply.  Important! This can only be X1, X2, X4, or X8|
|ActivationMode|Hold|How the key will activate the speed change.  Toggle = tapping the key cycles between on or off.  Hold = Holding the key activates, releasing deactivates|
|DoNotStopOnSpeedKeyDown|true|When set to `true`, will not stop the player's movement when the Speed Toggle Key is pressed.  `false` uses the game's default logic where any key press will stop the player's queued movement.|


## Key List
The list of valid keyboard keys can be found  at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

# Support
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.
Thanks!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/QM_SpeedToggle

# Change Log

# 1.3.0
* Compatible with 0.8.6

# 1.2.0
* 0.8.5 added logic to stop player movement when any key is pressed.  This update has the option DoNotStopOnSpeedKeyDown to ignore the Speed Toggle Key.  It is enabled by default.

# 1.1.1
* Changed default config to use Hold instead of Toggle activation

# 1.1.0
* Moved config file directory.
* Changed default activation from Toggle to Hold.
