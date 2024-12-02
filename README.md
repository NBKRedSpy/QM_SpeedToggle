# Quasimorph Speed Toggle

![thumbnail icon](media/thumbnail.png)

Want to move across the map quickly, but don't want to want combat to be at x8 speed all the time?
This mod allows the player to temporarily change the game's "animation speed" to x8 by pressing a key.

By default, the Caps Lock key is used as a toggle to enable or disable the speed change.

The mod can be configured as follows:
* The key to activate the speed change.
* If the key is held down or toggles the speed change.
* The speed to use.  

See the [Configuration](#configuration) section below.

# Configuration

The configuration file will be created on the first game run and can be found at `%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph\QM_SpeedToggle\config.json`.

|Name|Default|Description|
|--|--|--|
|ToggleKey|CapsLock|The key that will activate the speed change.  See the [Key List](#key-list) section.|
|AnimationSpeed|X8|The speed change to apply.  Important! This can only be X1, X2, X4, or X8|
|ActivationMode|Toggle|How the key will activate the speed change.  Toggle = tapping the key cycles between on or off.  Hold = Holding the key activates, releasing deactivates|


## Key List
The list of valid keyboard keys can be found  at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

# Support
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.
Thanks!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/QM_SpeedToggle
