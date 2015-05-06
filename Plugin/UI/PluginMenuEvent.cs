using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PluginMenuEvent : MonoBehaviour 
{
	public Material contrastIntensityMaterial;
	public GameObject[] menuButtons;
	public Slider contrastSlider;

	// All cameras in the scene
	private Camera[] cameras;

	// Variables menu activated/desactivated
	private bool menuEnabled;
	private bool flagMenuActivate;

	// Variables High contrast mode
	private bool highContrastEnabled;

	// Variables colorBlind
	private bool colorBlindEnabled;

	void Start()
	{
		menuEnabled = false;
		flagMenuActivate = false;
		highContrastEnabled = false;
		colorBlindEnabled = false;

		for (int i = 0; i < menuButtons.Length; i++)
			menuButtons[i].SetActive(false);

		cameras = Camera.allCameras;
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


	// Activation of the menu
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
		{
			menuEnabled = true;
		}
	}


	// Contrast option
	public void ActiveHighContrastMode()
	{
		if (menuEnabled)
		{
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
					cameras[i].gameObject.GetComponent<ContrastIntensity>().SetMaterial(contrastIntensityMaterial);
				}
				highContrastEnabled = true;
			}
		}
	}

	public void ContrastOnValueChanged()
	{
		if (menuEnabled && highContrastEnabled)
		{
			for (int i = 0; i < cameras.Length; i++)
				cameras[i].gameObject.GetComponent<ContrastIntensity>().SetIntensity(contrastSlider.value);
		}
	}


	// Color blind option
	public void ActiveColorblindUI()
	{
		if (menuEnabled && colorBlindEnabled)
		{
			// Desactivate color blind mode
			colorBlindEnabled = false;

		}
		else if (menuEnabled && !colorBlindEnabled)
		{
			// Activate color blind mode
			colorBlindEnabled = true;

		}
	}


	// Time regulation
	public void RegulateTime()
	{

	}
}