using System;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
class ContrastIntensity : MonoBehaviour
{
	public float intensity = 3f;
	public Material contrastMaterial;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		contrastMaterial.SetFloat("intensity", intensity);
		Graphics.Blit(source, destination, contrastMaterial);
	}
}