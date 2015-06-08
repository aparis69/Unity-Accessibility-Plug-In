using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PluginMenuEventAdvanced : PluginMenuEvent
{
	public Slider mouseSensivitySlider;
	public Toggle doubleStrikingOption;

	void Start()
	{
		Initialization();
	}
	
	void Update () 
	{
		if (menuEnabled && !flagMenuActivate)
		{
			flagMenuActivate = true;

			// Show the options of the menu
			for (int i = 0; i < menuButtons.Length; i++)
				menuButtons[i].SetActive(true);
		}
	}



	public void MouseSensivityValueChanged()
	{
		InputAccess.SetMouseSensivity(mouseSensivitySlider.value);
	}

	public void SetDoubleStrikingOption()
	{
		InputAccess.SetDoubleStrikingOption(doubleStrikingOption.isOn);
	}
}
