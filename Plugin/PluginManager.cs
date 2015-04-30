using UnityEngine;
using System.Collections;

public class PluginManager : MonoBehaviour 
{
	public bool calibrationMode;
	
	private KeyboardTracker keyboardTracker;
	private MouseTracker mouseTracker;
	private GenericTracker genericTracker;
	private UserData playerData;

	void Start ()
	{
		playerData = new UserData();
		keyboardTracker = this.GetComponent<KeyboardTracker>();
		mouseTracker = this.GetComponent<MouseTracker>();
		genericTracker = this.GetComponent<GenericTracker>();

		if (PlayerPrefs.GetInt("CalibrationMode") == 1)
			calibrationMode = false;
		else
			calibrationMode = true;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			// Stop the tracking
			keyboardTracker.SetAnalyse(false);
			mouseTracker.SetAnalyse(false);
			genericTracker.SetAnalyse(false);

			playerData.SetKeyboardInput(keyboardTracker.GetKeyboardInput());
			playerData.SetMouseInput(mouseTracker.GetMouseInput());

			// Calibration : storage
			if (calibrationMode)
			{
				DataStorage.StoreCalibrateData(playerData);
			}
			// Analysis : get the calibrate data back, and compare
			else
			{
				UserData calibrateData = DataStorage.GetCalibrateData();
				KeyboardAnalyser.CompareData(calibrateData, playerData);
				MouseAnalyser.CompareData(calibrateData, playerData);
			}
		}
	}
}