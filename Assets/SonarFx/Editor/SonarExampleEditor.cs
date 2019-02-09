using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SonarExample))]
public class SonarExampleEditor : Editor
{
	SerializedProperty propMode;
	SerializedProperty propOrigin;
	SerializedProperty propDirection;
	SerializedProperty propBaseColor;
	SerializedProperty propWaveColor;
	SerializedProperty propWaveAmplitude;
	SerializedProperty propWaveExponent;
	SerializedProperty propWaveInterval;
	SerializedProperty propWaveSpeed;
	SerializedProperty propAddColor;
	SerializedProperty propDuration;
	SonarExample targetObject;

	void OnEnable()
	{
		propMode = serializedObject.FindProperty("_mode");
		propOrigin = serializedObject.FindProperty("_origin");
		propDirection = serializedObject.FindProperty("_direction");
		propWaveColor = serializedObject.FindProperty("_waveColor");
		propWaveAmplitude = serializedObject.FindProperty("_waveAmplitude");
		propWaveExponent = serializedObject.FindProperty("_waveExponent");
		propWaveInterval = serializedObject.FindProperty("_waveInterval");
		propWaveSpeed = serializedObject.FindProperty("_waveSpeed");
		propDuration = serializedObject.FindProperty("_duration");
		targetObject = serializedObject.targetObject as SonarExample;
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(propMode);
		EditorGUILayout.PropertyField(propDuration);

		EditorGUI.indentLevel++;

		if (propMode.hasMultipleDifferentValues ||
			propMode.enumValueIndex == (int)SonarFx.SonarMode.Directional)
			EditorGUILayout.PropertyField(propDirection);

		if (propMode.hasMultipleDifferentValues ||
			propMode.enumValueIndex == (int)SonarFx.SonarMode.Spherical)
			EditorGUILayout.PropertyField(propOrigin);

		EditorGUI.indentLevel--;

		EditorGUILayout.LabelField("Wave Parameters");
		EditorGUI.indentLevel++;
		EditorGUILayout.PropertyField(propWaveColor, new GUIContent("Color"));
		EditorGUILayout.PropertyField(propWaveAmplitude, new GUIContent("Amplitude"));
		EditorGUILayout.PropertyField(propWaveExponent, new GUIContent("Exponent"));
		EditorGUILayout.PropertyField(propWaveInterval, new GUIContent("Interval"));
		EditorGUILayout.PropertyField(propWaveSpeed, new GUIContent("Speed"));
		EditorGUI.indentLevel--;
		if (GUILayout.Button("Start Sonar"))
		{
			targetObject.StartSonar();
		}

		serializedObject.ApplyModifiedProperties();
	}
}
