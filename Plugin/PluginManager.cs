using UnityEngine;
using System.Collections;

public class PluginManager : MonoBehaviour 
{
	public bool calibrationMode;
	
	private KeyboardTracker keyboardTracker;
	private MouseTracker mouseTracker;
	private UserData playerData;

	void Start ()
	{
		playerData = new UserData();
		keyboardTracker = this.GetComponent<KeyboardTracker>();
		mouseTracker = this.GetComponent<MouseTracker>();
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			// Stop the tracking
			keyboardTracker.SetAnalyse(false);
			mouseTracker.SetAnalyse(false);

			playerData.SetKeyboardInput(keyboardTracker.GetKeyboardInput());
			playerData.SetMouseInput(mouseTracker.GetMouseInput());

			if (calibrationMode)
			{
				DataStorage.StoreCalibrateData(playerData);
			}
			else
			{
				UserData calibrateData = DataStorage.GetCalibrateData();
				KeyboardAnalyser.CompareData(calibrateData, playerData);
				MouseAnalyser.CompareData(calibrateData, playerData);
			}
		}
	}
}