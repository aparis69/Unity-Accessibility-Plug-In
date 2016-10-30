using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PluginMenuEvent : MonoBehaviour
{
	// All menu objects	
	public GameObject[] menuButtons;

	// Variables Subtitle management
	public SubtitleManagement subtitleManager;

	// Variables Sound management
	public SoundManager soundManager;

	// Variable time management
	public Slider timeSlider;

	// Variable Colorblind
	public CBFixGUI CBscript;

	// All cameras in the scene
	protected Camera[] cameras;

	// Variables menu activated/desactivated
	protected bool menuEnabled;

	// Variables High contrast mode
	public Material contrastIntensityMaterial;
	public Slider contrastSlider;
	protected bool highContrastEnabled;

	// Variables Edge Detection mode
	public Material edgeDetectionMaterial;
	public Slider edgeWidthSlider;
	public Slider edgeBgAmountSlider;
	protected bool edgeDetectionEnabled;

	void Start()
	{
		Initialization();
	}

	protected void Initialization()
	{
		menuEnabled = false;
		highContrastEnabled = false;
		edgeDetectionEnabled = false;

		for (int i = 0; i < menuButtons.Length; i++)
			menuButtons[i].SetActive(false);

		cameras = Camera.allCameras;
	}

	void Update()
	{

	}


	// Activation of the menu
	public void ActiveAccessibilityMenu()
	{
		if (menuEnabled)
		{
			menuEnabled = false;

			// Desactivate the options of the menu
			for (int i = 0; i < menuButtons.Length; i++)
				menuButtons[i].SetActive(false);

			edgeBgAmountSlider.gameObject.SetActive(false);
			edgeWidthSlider.gameObject.SetActive(false);
			contrastSlider.gameObject.SetActive(false);
		}
		else
		{
			menuEnabled = true;

			// Show the options of the menu
			for (int i = 0; i < menuButtons.Length; i++)
				menuButtons[i].SetActive(true);

			if (edgeDetectionEnabled == true)
			{
				edgeBgAmountSlider.gameObject.SetActive(true);
				edgeWidthSlider.gameObject.SetActive(true);
			}
			if (highContrastEnabled == true)
				contrastSlider.gameObject.SetActive(true);
		}
	}


	// High Contrast Option
	public void ActiveHighContrastMode()
	{
		if (menuEnabled)
		{
			if (highContrastEnabled)
			{
				for (int i = 0; i < cameras.Length; i++)
					GameObject.Destroy(cameras[i].gameObject.GetComponent<ContrastIntensity>());
				highContrastEnabled = false;
				contrastSlider.gameObject.SetActive(false);
			}
			else
			{
				for (int i = 0; i < cameras.Length; i++)
				{
					cameras[i].gameObject.AddComponent<ContrastIntensity>();
					cameras[i].gameObject.GetComponent<ContrastIntensity>().SetMaterial(contrastIntensityMaterial);
				}
				highContrastEnabled = true;
				contrastSlider.gameObject.SetActive(true);
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


	public void ActiveEdgeDetectionMode()
	{
		if (menuEnabled)
		{
			if (edgeDetectionEnabled)
			{
				for (int i = 0; i < cameras.Length; i++)
					GameObject.Destroy(cameras[i].gameObject.GetComponent<EdgeDetectionEffect>());
				edgeDetectionEnabled = false;
				edgeWidthSlider.gameObject.SetActive(false);
				edgeBgAmountSlider.gameObject.SetActive(false);
			}
			else
			{
				for (int i = 0; i < cameras.Length; i++)
				{
					cameras[i].gameObject.AddComponent<EdgeDetectionEffect>();
					cameras[i].gameObject.GetComponent<EdgeDetectionEffect>().SetMaterial(edgeDetectionMaterial);
				}
				edgeDetectionEnabled = true;
				edgeWidthSlider.gameObject.SetActive(true);
				edgeBgAmountSlider.gameObject.SetActive(true);
			}
		}
	}

	public void EdgeWidthChanged()
	{
		if (menuEnabled && edgeDetectionEnabled)
		{
			for (int i = 0; i < cameras.Length; i++)
				cameras[i].gameObject.GetComponent<EdgeDetectionEffect>().SetEdgeWidth(edgeWidthSlider.value);
		}
	}
	public void EdgeBgAmountChanged()
	{
		if (menuEnabled && edgeDetectionEnabled)
		{
			for (int i = 0; i < cameras.Length; i++)
				cameras[i].gameObject.GetComponent<EdgeDetectionEffect>().SetBgAmount(edgeBgAmountSlider.value);
		}
	}
	


	// Color blind Option
	public void ActiveColorblindUI()
	{
		if (menuEnabled)
			CBscript.UpdateColorBlindnessType();
	}


	// Time Regulation
	public void RegulateTime()
	{
		Time.timeScale = timeSlider.value;
	}


	// Subtitle Interface Option
	public void ShowSubtitleManagementInterface()
	{
		subtitleManager.SwitchDisplay();
	}

	// Sound Management Interface Option
	public void ShowSoundManagementInterface()
	{
		soundManager.SwitchDisplay();
	}
}