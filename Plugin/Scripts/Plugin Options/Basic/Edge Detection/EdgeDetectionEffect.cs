using System;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
class EdgeDetectionEffect : MonoBehaviour
{
	public float sensitivityDepth = 1.0f;
	public float sensitivityNormals = 1.0f;
	public float sampleDist = 1.0f;
	public float edgesOnly = 0.0f;

	public Material edgeDetectMaterial = null;

	public void SetCameraFlag()
	{
		GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	void OnEnable()
	{
		SetCameraFlag();
	}

	public void SetMaterial(Material m)
	{
		edgeDetectMaterial = m;
	}

	public void SetEdgeWidth(float i)
	{
		sampleDist = i;
	}

	public void SetBgAmount(float i)
	{
		edgesOnly = 1.0f - i;
	}


	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Vector2 sensitivity = new Vector2(sensitivityDepth, sensitivityNormals);
		edgeDetectMaterial.SetVector("_Sensitivity", new Vector4(sensitivity.x, sensitivity.y, 1.0f, 1.0f));
		edgeDetectMaterial.SetFloat("_FadeToWhite", edgesOnly);
		edgeDetectMaterial.SetFloat("_SampleDistance", sampleDist);

		Graphics.Blit(source, destination, edgeDetectMaterial);
	}
}