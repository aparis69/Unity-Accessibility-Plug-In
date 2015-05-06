using UnityEngine;
using System.Collections;

public class PluginMenuEvent : MonoBehaviour 
{
	public GameObject[] menuButtons;

	private bool menuEnabled;
	private bool flagMenuActivate;

	public UnityEngine.UI.Slider timeSlider;

	void Start()
	{
		menuEnabled = false;
		flagMenuActivate = false;

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

	}

	public void ActiveColorblindUI()
	{

	}

	public void RegulateTime()
	{
		Time.timeScale = timeSlider.value;
	}
}