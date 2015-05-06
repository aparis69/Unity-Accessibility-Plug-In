using UnityEngine;
using System.Collections;

public class PluginMenuEvent : MonoBehaviour 
{
	public Material contrastIntensityMaterial;
	public GameObject[] menuButtons;

	// Variables menu activated/desactivated
	private bool menuEnabled;
	private bool flagMenuActivate;

	// Variables High contrast mode
	private bool highContrastEnabled;

	void Start()
	{
		menuEnabled = false;
		flagMenuActivate = false;
		highContrastEnabled = false;

		for (int i = 0; i < menuButtons.Length; i++)
			menuButtons[i].SetActive(false);
	}

	void Update()
	{
		if (menuEnabled && !flagMenuActivate)
		{
			flagMenuActivate = true;

			// Show the options of the menu
			for (int i = 0; i < menuButtons.Length; i++)
				menuButtons[i].SetActive(true);
		}
	}

	public void ActiveAccessibilityMenu()
	{
		if (menuEnabled)
		{
			menuEnabled = false;
			flagMenuActivate = false;

			// Desactivate the options of the menu
			for (int i = 0; i < menuButtons.Length; i++)
				menuButtons[i].SetActive(false);
		}
		else
			menuEnabled = true;
	}

	public void ActiveHighContrastMode()
	{
		if (menuEnabled)
		{
			Camera[] cameras = Camera.allCameras;
			if (highContrastEnabled)
			{
				for (int i = 0; i < cameras.Length; i++)
					GameObject.Destroy(cameras[i].gameObject.GetComponent<ContrastIntensity>());
				highContrastEnabled = false;
			}
			else
			{
				for (int i = 0; i < cameras.Length; i++)
				{
					cameras[i].gameObject.AddComponent<ContrastIntensity>();
					cameras[i].gameObject.GetComponent<ContrastIntensity>().contrastMaterial = contrastIntensityMaterial;
				}
				highContrastEnabled = true;
			}
		}
	}

	public void ActiveColorblindUI()
	{

	}

	public void RegulateTime()
	{

	}
}