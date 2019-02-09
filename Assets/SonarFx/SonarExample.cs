using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarExample : MonoBehaviour
{
	[SerializeField] SonarFx.SonarMode _mode = SonarFx.SonarMode.Directional;

	[SerializeField] float _duration = 5;

	// Wave direction (used only in the directional mode)
	[SerializeField] Vector3 _direction = Vector3.forward;

	// Wave origin (used only in the spherical mode)
	[SerializeField] Vector3 _origin = Vector3.zero;

	// Wave color
	[SerializeField] Gradient _waveColor = new Gradient();

	// Wave color amplitude
	[SerializeField] float _waveAmplitude = 2.0f;

	// Exponent for wave color
	[SerializeField] float _waveExponent = 22.0f;

	// Interval between waves
	[SerializeField] float _waveInterval = 20.0f;

	// Wave speed
	[SerializeField] float _waveSpeed = 10.0f;

	public void StartSonar()
	{
		SonarFxDescriptor descriptor = new SonarFxDescriptor
		{
			mode = _mode,
			duration = _duration,
			direction = _direction,
			origin = _origin,
			waveColor = _waveColor,
			waveAmplitude = _waveAmplitude,
			waveExponent = _waveExponent,
			waveInterval = _waveInterval,
			waveSpeed = _waveSpeed
		};

		SonarFx.Instance.StartSonar(descriptor);
	}
}
