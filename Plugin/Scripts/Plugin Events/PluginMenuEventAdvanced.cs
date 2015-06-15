using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PluginMenuEventAdvanced : PluginMenuEvent
{
	public Slider mouseSensivitySlider;
	public Toggle doubleStrikingOption;

	public SoundManager soundManager;

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

	// Show the sound manager interface on the screen
	public void ShowSoundManagerInterface()
	{
		soundManager.SwitchDisplay();
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
