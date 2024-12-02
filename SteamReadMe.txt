[h1]Quasimorph Speed Toggle[/h1]


Want to move across the map quickly, but don't want to want combat to be at x8 speed all the time?
This mod allows the player to temporarily change the game's "animation speed" to x8 by pressing a key.

By default, the Caps Lock key is used as a toggle to enable or disable the speed change.

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

The configuration file will be created on the first game run and can be found at [i]%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph\QM_SpeedToggle\config.json[/i].
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
[/table]

[h2]Key List[/h2]

The list of valid keyboard keys can be found  at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

[h1]Support[/h1]

If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.
Thanks!

[h1]Source Code[/h1]

Source code is available on GitHub at https://github.com/NBKRedSpy/QM_SpeedToggle
