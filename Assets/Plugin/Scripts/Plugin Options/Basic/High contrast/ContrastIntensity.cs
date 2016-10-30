using System;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
class ContrastIntensity : MonoBehaviour
{
	private float intensity = 3f;
	private Material contrastMaterial;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		contrastMaterial.SetFloat("intensity", intensity);
		Graphics.Blit(source, destination, contrastMaterial);
	}

	public void SetMaterial(Material m)
	{
		contrastMaterial = m;
	}

	public void SetIntensity(float i)
	{
		intensity = i;
	}
}