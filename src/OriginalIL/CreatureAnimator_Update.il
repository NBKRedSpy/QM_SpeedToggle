.method private hidebysig 
	instance void Update () cil managed 
{
	// Method begins at RVA 0xe6bc0
	// Header size: 12
	// Code size: 131 (0x83)
	.maxstack 2
	.locals init (
		[0] float32,
		[1] valuetype MGSC.CreatureAnimationSpeed,
		[2] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.CreatureAnimation>,
		[3] class MGSC.CreatureAnimation
	)

	// float num = Time.deltaTime;
	IL_0000: call float32 [UnityEngine.CoreModule]UnityEngine.Time::get_deltaTime()
	IL_0005: stloc.0
	// switch (_gameSettings.CreatureAnimationSpeed)
	IL_0006: ldarg.0
	IL_0007: ldfld class MGSC.GameSettings MGSC.CreatureAnimator::_gameSettings
	IL_000c: callvirt instance valuetype MGSC.CreatureAnimationSpeed MGSC.GameSettings::get_CreatureAnimationSpeed()
	IL_0011: stloc.1
	// (no C# code)
	IL_0012: ldloc.1
	IL_0013: ldc.i4.1
	IL_0014: sub
	IL_0015: switch (IL_0028, IL_0032, IL_003c)

	// num *= 2f;
	IL_0026: br.s IL_0044

	IL_0028: ldloc.0
	IL_0029: ldc.r4 2
	IL_002e: mul
	IL_002f: stloc.0
	// break;
	IL_0030: br.s IL_0044

	// num *= 4f;
	IL_0032: ldloc.0
	IL_0033: ldc.r4 4
	IL_0038: mul
	IL_0039: stloc.0
	// break;
	IL_003a: br.s IL_0044

	// num *= 8f;
	IL_003c: ldloc.0
	IL_003d: ldc.r4 8
	IL_0042: mul
	IL_0043: stloc.0

	// foreach (CreatureAnimation currentAnimation in _currentAnimations)
	IL_0044: ldarg.0
	IL_0045: ldfld class [mscorlib]System.Collections.Generic.List`1<class MGSC.CreatureAnimation> MGSC.CreatureAnimator::_currentAnimations
	IL_004a: callvirt instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class MGSC.CreatureAnimation>::GetEnumerator()
	IL_004f: stloc.2
	.try
	{
		// foreach (CreatureAnimation currentAnimation in _currentAnimations)
		IL_0050: br.s IL_0069
		// loop start (head: IL_0069)
			IL_0052: ldloca.s 2
			IL_0054: call instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.CreatureAnimation>::get_Current()
			IL_0059: stloc.3
			// if (currentAnimation.AnimationInProgress)
			IL_005a: ldloc.3
			IL_005b: callvirt instance bool MGSC.CreatureAnimation::get_AnimationInProgress()
			IL_0060: brfalse.s IL_0069

			// currentAnimation.Process(num);
			IL_0062: ldloc.3
			IL_0063: ldloc.0
			IL_0064: callvirt instance void MGSC.CreatureAnimation::Process(float32)

			// foreach (CreatureAnimation currentAnimation in _currentAnimations)
			IL_0069: ldloca.s 2
			IL_006b: call instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.CreatureAnimation>::MoveNext()
			// (no C# code)
			IL_0070: brtrue.s IL_0052
		// end loop

		IL_0072: leave.s IL_0082
	} // end .try
	finally
	{
		IL_0074: ldloca.s 2
		IL_0076: constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.CreatureAnimation>
		IL_007c: callvirt instance void [mscorlib]System.IDisposable::Dispose()
		IL_0081: endfinally
	} // end handler

	IL_0082: ret
} // end of method CreatureAnimator::Update
