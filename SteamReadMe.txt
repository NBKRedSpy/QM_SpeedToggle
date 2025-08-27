[h1]Quasimorph Speed Toggle[/h1]


Want to move across the map quickly, but don't want to want combat to be at x8 speed all the time?
This mod allows the player to temporarily change the game's "animation speed" to x8 by holding a key.

By default, holding down the Caps Lock key will set the animation speed to x8, and releasing it will return to the game's animation speed setting.

The mod can be configured as follows:
[list]
[*]The key to activate the speed change.
[*]If the key is held down or toggles the speed change.
[*]The speed to use.
[/list]

See the Configuration section below.

[h1]Monster Detection[/h1]

The [url=https://steamcommunity.com/sharedfiles/filedetails/?id=3292592993]Stop on Monster Detection[/url] mod is recommended.  It prevents monsters that are spotted (the asterisk icon) from ambushing the player.

[h1]Configuration[/h1]

The configuration file will be created on the first game run and can be found at [i]%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\QM_SpeedToggle\config.json[/i].
[table]
[tr]
[td]Name
[/td]
[td]Default
[/td]
[td]Description
[/td]
[/tr]
[tr]
[td]ToggleKey
[/td]
[td]CapsLock
[/td]
[td]The key that will activate the speed change.  See the Key List section.
[/td]
[/tr]
[tr]
[td]AnimationSpeed
[/td]
[td]X8
[/td]
[td]The speed change to apply.  Important! This can only be X1, X2, X4, or X8
[/td]
[/tr]
[tr]
[td]ActivationMode
[/td]
[td]Toggle
[/td]
[td]How the key will activate the speed change.  Toggle = tapping the key cycles between on or off.  Hold = Holding the key activates, releasing deactivates
[/td]
[/tr]
[tr]
[td]DoNotStopOnSpeedKeyDown
[/td]
[td]true
[/td]
[td]When set to [i]true[/i], will not stop the player's movement when the Speed Toggle Key is pressed.  [i]false[/i] uses the game's default logic where any key press will stop the player's queued movement.
[/td]
[/tr]
[/table]

[h2]Key List[/h2]

The list of valid keyboard keys can be found  at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

[h1]Support[/h1]

If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.
Thanks!

[h1]Credits[/h1]
[list]
[*]Special thanks to Crynano for his excellent Mod Configuration Menu.
[/list]

[h1]Source Code[/h1]

Source code is available on GitHub at https://github.com/NBKRedSpy/QM_SpeedToggle

[h1]Change Log[/h1]

[h1]1.5.0[/h1]
[list]
[*]MCM integration
[*]Changed default mode to Toggle from Hold.
[/list]

[h1]1.4.0[/h1]
[list]
[*]Instant door opening.  When the speed is enabled, the doors will not cause the merc to pause.  This does not affect the game in any way; it simply removes the door opening animation.  This makes moving through multiple doors much faster.
[/list]

[h1]1.3.0[/h1]
[list]
[*]Compatible with 0.8.6
[/list]

[h1]1.2.0[/h1]
[list]
[*]0.8.5 added logic to stop player movement when any key is pressed.  This update has the option DoNotStopOnSpeedKeyDown to ignore the Speed Toggle Key.  It is enabled by default.
[/list]

[h1]1.1.1[/h1]
[list]
[*]Changed default config to use Hold instead of Toggle activation
[/list]

[h1]1.1.0[/h1]
[list]
[*]Moved config file directory.
[*]Changed default activation from Toggle to Hold.
[/list]
