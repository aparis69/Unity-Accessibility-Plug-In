using UnityEngine;
using System.Collections;

public class PluginMenuEventAdvanced : PluginMenuEvent
{
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
	}
}
