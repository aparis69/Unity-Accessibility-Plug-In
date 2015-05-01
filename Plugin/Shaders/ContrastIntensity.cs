using System;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
class ContrastIntensity
{
	public float intensity = 0.5f;
	public Material contrastMaterial;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		contrastMaterial.SetFloat("intensity", intensity);
		Graphics.Blit(source, destination, contrastMaterial);
	}
}

