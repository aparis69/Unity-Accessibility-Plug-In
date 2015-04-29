using UnityEngine;
using System.Collections;

public class PluginManager : MonoBehaviour 
{
	public bool calibrationMode;
	
	private KeyboardTracker keyboardTracker;
	private MouseTracker mouseTracker;
	private UserData playerData;

	private float analyseTime = 30f;
	private float time;

	void Start ()
	{
		playerData = new UserData();
		keyboardTracker = this.GetComponent<KeyboardTracker>();
		mouseTracker = this.GetComponent<MouseTracker>();

		time = Time.realtimeSinceStartup + analyseTime;
	}
	
	void Update () 
	{
		if (Time.realtimeSinceStartup > time)
		{
			playerData.SetKeyboardInput(keyboardTracker.GetKeyboardInput());
			//playerData.SetMouseInput(mouseTracker.getMouseInput());

			if (calibrationMode)
			{
				DataStorage.StoreCalibrateData(playerData);
			}
			else
			{
				UserData calibrateData = DataStorage.GetCalibrateData();
				KeyboardAnalyser.CompareData(null, playerData);
				//MouseAnalyser.CompareData();
			}
		}
	}
}