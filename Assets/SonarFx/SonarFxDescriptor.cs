using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SonarFxDescriptor
{
	public SonarFx.SonarMode mode;
	public float duration;
	public Vector3 direction;
	public Vector3 origin;
	public Gradient waveColor;
	public float waveAmplitude;
	public float waveExponent;
	public float waveInterval;
	public float waveSpeed;

	public static SonarFxDescriptor defaultDescriptor
	{
		get
		{
			return new SonarFxDescriptor
			{
				mode = SonarFx.SonarMode.Spherical,
				duration = 5f,
				direction = Vector3.forward,
				origin = Vector3.zero,
				waveColor = new Gradient(),
				waveAmplitude = 2,
				waveExponent = 22,
				waveInterval = 20,
				waveSpeed = 10,
			};
		}
	}
}
