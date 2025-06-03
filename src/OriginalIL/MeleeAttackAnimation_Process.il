.method public hidebysig virtual 
	instance void Process (
		float32 deltaTime
	) cil managed 
{
	// Method begins at RVA 0xe48c8
	// Header size: 12
	// Code size: 366 (0x16e)
	.maxstack 6
	.locals init (
		[0] float32,
		[1] valuetype [UnityEngine.CoreModule]UnityEngine.Vector3,
		[2] float32,
		[3] valuetype MGSC.CreatureAnimationSpeed
	)

	// float num = 1f;
	IL_0000: ldc.r4 1
	IL_0005: stloc.0
	// switch (SingletonMonoBehaviour<GameSettings>.Instance.CreatureAnimationSpeed)
	IL_0006: call !0 class MGSC.SingletonMonoBehaviour`1<class MGSC.GameSettings>::get_Instance()
	IL_000b: callvirt instance valuetype MGSC.CreatureAnimationSpeed MGSC.GameSettings::get_CreatureAnimationSpeed()
	IL_0010: stloc.3
	// (no C# code)
	IL_0011: ldloc.3
	IL_0012: ldc.i4.1
	IL_0013: sub
	IL_0014: switch (IL_0027, IL_002f, IL_0037)

	// num = 2f;
	IL_0025: br.s IL_003d

	IL_0027: ldc.r4 2
	IL_002c: stloc.0
	// break;
	IL_002d: br.s IL_003d

	// num = 4f;
	IL_002f: ldc.r4 4
	IL_0034: stloc.0
	// break;
	IL_0035: br.s IL_003d

	// num = 8f;
	IL_0037: ldc.r4 8
	IL_003c: stloc.0

	// if (ControlsCamera)
	IL_003d: ldarg.0
	IL_003e: call instance bool MGSC.MeleeAttackAnimation::get_ControlsCamera()
	IL_0043: brfalse.s IL_005b

	// _gameCamera.CameraFollowBone.position = _startPosition;
	IL_0045: ldarg.0
	IL_0046: ldfld class MGSC.GameCamera MGSC.MeleeAttackAnimation::_gameCamera
	IL_004b: callvirt instance class [UnityEngine.CoreModule]UnityEngine.Transform MGSC.GameCamera::get_CameraFollowBone()
	IL_0050: ldarg.0
	IL_0051: ldfld valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 MGSC.MeleeAttackAnimation::_startPosition
	IL_0056: callvirt instance void [UnityEngine.CoreModule]UnityEngine.Transform::set_position(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3)

	// if (_delayTimer.Time * num < _delay)
	IL_005b: ldarg.0
	IL_005c: ldfld class MGSC.Timer MGSC.MeleeAttackAnimation::_delayTimer
	IL_0061: callvirt instance float32 MGSC.Timer::get_Time()
	IL_0066: ldloc.0
	IL_0067: mul
	IL_0068: ldarg.0
	IL_0069: ldfld float32 MGSC.MeleeAttackAnimation::_delay
	IL_006e: bge.un.s IL_0071

	// }
	IL_0070: ret

	// Vector3 vector = Vector3.Lerp(_startPosition, _mapRenderer.GetCreatureWorldPos(_victimPos), _maxT);
	IL_0071: ldarg.0
	IL_0072: ldfld valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 MGSC.MeleeAttackAnimation::_startPosition
	IL_0077: ldarg.0
	IL_0078: ldfld class MGSC.MapRenderer MGSC.MeleeAttackAnimation::_mapRenderer
	IL_007d: ldarg.0
	IL_007e: ldfld valuetype MGSC.CellPosition MGSC.MeleeAttackAnimation::_victimPos
	IL_0083: callvirt instance valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 MGSC.MapRenderer::GetCreatureWorldPos(valuetype MGSC.CellPosition)
	IL_0088: ldarg.0
	IL_0089: ldfld float32 MGSC.MeleeAttackAnimation::_maxT
	IL_008e: call valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Vector3::Lerp(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, float32)
	IL_0093: stloc.1
	// float num2 = _delayTimer.Time * num - _delay;
	IL_0094: ldarg.0
	IL_0095: ldfld class MGSC.Timer MGSC.MeleeAttackAnimation::_delayTimer
	IL_009a: callvirt instance float32 MGSC.Timer::get_Time()
	IL_009f: ldloc.0
	IL_00a0: mul
	IL_00a1: ldarg.0
	IL_00a2: ldfld float32 MGSC.MeleeAttackAnimation::_delay
	IL_00a7: sub
	IL_00a8: stloc.2
	// if (num2 > Duration)
	IL_00a9: ldloc.2
	IL_00aa: ldarg.0
	IL_00ab: ldfld float32 MGSC.CreatureAnimation::Duration
	IL_00b0: ble.un.s IL_00f3

	// _rootMotionBone.position = _startPosition;
	IL_00b2: ldarg.0
	IL_00b3: ldfld class [UnityEngine.CoreModule]UnityEngine.Transform MGSC.CreatureAnimation::_rootMotionBone
	IL_00b8: ldarg.0
	IL_00b9: ldfld valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 MGSC.MeleeAttackAnimation::_startPosition
	IL_00be: callvirt instance void [UnityEngine.CoreModule]UnityEngine.Transform::set_position(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3)
	// if (num2 - Duration > 0.1f)
	IL_00c3: ldloc.2
	IL_00c4: ldarg.0
	IL_00c5: ldfld float32 MGSC.CreatureAnimation::Duration
	IL_00ca: sub
	IL_00cb: ldc.r4 0.1
	IL_00d0: ble.un.s IL_00f2

	// if (!_wasHit)
	IL_00d2: ldarg.0
	IL_00d3: ldfld bool MGSC.MeleeAttackAnimation::_wasHit
	IL_00d8: brtrue.s IL_00ec

	// _wasHit = true;
	IL_00da: ldarg.0
	IL_00db: ldc.i4.1
	IL_00dc: stfld bool MGSC.MeleeAttackAnimation::_wasHit
	// this.OnHitFrameReached();
	IL_00e1: ldarg.0
	IL_00e2: ldfld class [mscorlib]System.Action MGSC.MeleeAttackAnimation::OnHitFrameReached
	IL_00e7: callvirt instance void [mscorlib]System.Action::Invoke()

	// FinishAnimation();
	IL_00ec: ldarg.0
	IL_00ed: callvirt instance void MGSC.CreatureAnimation::FinishAnimation()

	// if (num2 < _meleeHitDuration)
	IL_00f2: ret

	IL_00f3: ldloc.2
	IL_00f4: ldarg.0
	IL_00f5: ldfld float32 MGSC.MeleeAttackAnimation::_meleeHitDuration
	IL_00fa: bge.un.s IL_011d

	// _rootMotionBone.position = Vector3.Lerp(_startPosition, vector, num2 / _meleeHitDuration);
	IL_00fc: ldarg.0
	IL_00fd: ldfld class [UnityEngine.CoreModule]UnityEngine.Transform MGSC.CreatureAnimation::_rootMotionBone
	IL_0102: ldarg.0
	IL_0103: ldfld valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 MGSC.MeleeAttackAnimation::_startPosition
	IL_0108: ldloc.1
	IL_0109: ldloc.2
	IL_010a: ldarg.0
	IL_010b: ldfld float32 MGSC.MeleeAttackAnimation::_meleeHitDuration
	IL_0110: div
	IL_0111: call valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Vector3::Lerp(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, float32)
	IL_0116: callvirt instance void [UnityEngine.CoreModule]UnityEngine.Transform::set_position(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3)
	// _rootMotionBone.position = Vector3.Lerp(vector, _startPosition, (num2 - _meleeHitDuration) / (Duration - _meleeHitDuration));
	IL_011b: br.s IL_014a

	IL_011d: ldarg.0
	IL_011e: ldfld class [UnityEngine.CoreModule]UnityEngine.Transform MGSC.CreatureAnimation::_rootMotionBone
	IL_0123: ldloc.1
	IL_0124: ldarg.0
	IL_0125: ldfld valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 MGSC.MeleeAttackAnimation::_startPosition
	IL_012a: ldloc.2
	IL_012b: ldarg.0
	IL_012c: ldfld float32 MGSC.MeleeAttackAnimation::_meleeHitDuration
	IL_0131: sub
	IL_0132: ldarg.0
	IL_0133: ldfld float32 MGSC.CreatureAnimation::Duration
	IL_0138: ldarg.0
	IL_0139: ldfld float32 MGSC.MeleeAttackAnimation::_meleeHitDuration
	IL_013e: sub
	IL_013f: div
	IL_0140: call valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Vector3::Lerp(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, float32)
	IL_0145: callvirt instance void [UnityEngine.CoreModule]UnityEngine.Transform::set_position(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3)

	// if (num2 >= _meleeHitDuration && !_wasHit)
	IL_014a: ldloc.2
	IL_014b: ldarg.0
	IL_014c: ldfld float32 MGSC.MeleeAttackAnimation::_meleeHitDuration
	IL_0151: blt.un.s IL_016d

	IL_0153: ldarg.0
	IL_0154: ldfld bool MGSC.MeleeAttackAnimation::_wasHit
	IL_0159: brtrue.s IL_016d

	// this.OnHitFrameReached();
	IL_015b: ldarg.0
	IL_015c: ldfld class [mscorlib]System.Action MGSC.MeleeAttackAnimation::OnHitFrameReached
	IL_0161: callvirt instance void [mscorlib]System.Action::Invoke()
	// _wasHit = true;
	IL_0166: ldarg.0
	IL_0167: ldc.i4.1
	IL_0168: stfld bool MGSC.MeleeAttackAnimation::_wasHit

	// (no C# code)
	IL_016d: ret
} // end of method MeleeAttackAnimation::Process
