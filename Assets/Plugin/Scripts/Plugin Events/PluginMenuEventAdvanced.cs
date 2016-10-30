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
