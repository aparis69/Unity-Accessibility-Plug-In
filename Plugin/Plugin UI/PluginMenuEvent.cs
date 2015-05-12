using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PluginMenuEvent : MonoBehaviour
{
	// All menu objects	
	public GameObject[] menuButtons;

	// Variables Sound Management
	public PluginSoundManager soundManager;

	// Variable time management
	public Slider timeSlider;

	// Variable Colorblind
	public CBFixGUI CBscript;

	// All cameras in the scene
	private Camera[] cameras;

	// Variables menu activated/desactivated
	private bool menuEnabled;
	private bool flagMenuActivate;

	// Variables High contrast mode
	public Material contrastIntensityMaterial;
	public Slider contrastSlider;
	private bool highContrastEnabled;

	void Start()
	{
		menuEnabled = false;
		flagMenuActivate = false;
		highContrastEnabled = false;

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
		if (menuEnabled)
			CBscript.UpdateColorBlindnessType();
	}


	// Time regulation
	public void RegulateTime()
	{
		Time.timeScale = timeSlider.value;
	}


	// Sound Management option
	public void ShowSoundManagementInterface()
	{
		soundManager.SwitchDisplay();
	}
}