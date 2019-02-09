//
// Sonar FX
//
// Copyright (C) 2013, 2014 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarFx : MonoSingleton<SonarFx>
{
	public enum SonarMode { Directional, Spherical };
    // Reference to the shader.
    [SerializeField] Shader sonarShader;
	[SerializeField] Shader AdditivedShader;
	[SerializeField] Camera camera;

	[SerializeField] RenderTexture texture;

	[SerializeField] List<SonarFxDescriptor> descriptors;
	[SerializeField] List<float> timers;
	
	Material blendMaterial;
	RenderTextureDescriptor descriptor;

	// Private shader variables
	int baseColorID;
    int waveColorID;
    int waveParamsID;
    int waveVectorID;
    int addColorID;
	int timeFactorID;
	int targetID;

	protected override void Awake()
	{
		baseColorID = Shader.PropertyToID("_SonarBaseColor");
        waveColorID = Shader.PropertyToID("_SonarWaveColor");
        waveParamsID = Shader.PropertyToID("_SonarWaveParams");
        waveVectorID = Shader.PropertyToID("_SonarWaveVector");
        addColorID = Shader.PropertyToID("_SonarAddColor");
		timeFactorID = Shader.PropertyToID("_SonarTimeFactor");
		targetID = Shader.PropertyToID("_TargetTex");

		blendMaterial = new Material(AdditivedShader);
		descriptors = new List<SonarFxDescriptor>();
		timers = new List<float>();

		descriptor = texture.descriptor;
	}

    void OnEnable()
	{
		camera.SetReplacementShader(sonarShader, null);
	}

    void OnDisable()
    {
		if (camera != null)
			camera.ResetReplacementShader();
    }

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		descriptor.width = Camera.main.pixelWidth;
		descriptor.height = Camera.main.pixelHeight;

		var tempTexure = RenderTexture.GetTemporary(descriptor);

		blendMaterial.SetTexture(targetID, source);
		camera.targetTexture = tempTexure;

		for (int i = 0; i < descriptors.Count; i++)
		{
			timers[i] -= Time.deltaTime;
			if (timers[i] <= 0)
			{
				timers.RemoveAt(i);
				descriptors.RemoveAt(i);
				i--;
				continue;
			}

			EvaluateSonar(timers[i], descriptors[i]);

			camera.Render();
			Graphics.Blit(tempTexure, source, blendMaterial);
		}
		
		Graphics.Blit(source, destination);

		RenderTexture.ReleaseTemporary(tempTexure);
	}

	public void StartSonar(SonarFxDescriptor descriptor)
	{
		descriptors.Add(descriptor);
		timers.Add(descriptor.duration);
	}

	private void EvaluateSonar(float time, SonarFxDescriptor descriptor)
	{
		var evaluationTime = 1 - time / descriptor.duration;
		var currentWaveColor = descriptor.waveColor.Evaluate(evaluationTime);
		var param = new Vector4(descriptor.waveAmplitude, descriptor.waveExponent, descriptor.waveInterval, descriptor.waveSpeed);

		Shader.SetGlobalColor(waveColorID, currentWaveColor);
		Shader.SetGlobalVector(waveParamsID, param);
		Shader.SetGlobalFloat(timeFactorID, descriptor.duration - time);
		if (descriptor.mode == SonarMode.Directional)
		{
			Shader.DisableKeyword("SONAR_SPHERICAL");
			Shader.SetGlobalVector(waveVectorID, descriptor.direction.normalized);
		}
		else
		{
			Shader.EnableKeyword("SONAR_SPHERICAL");
			Shader.SetGlobalVector(waveVectorID, descriptor.origin);
		}
	}
}
