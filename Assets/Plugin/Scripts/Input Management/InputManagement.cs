using UnityEngine;
using System.Collections;

public class InputManagement : MonoBehaviour 
{
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
	}

	public void SetData()
	{
		// Stop the tracking
		keyboardTracker.SetAnalyse(false);
		mouseTracker.SetAnalyse(false);
		genericTracker.SetAnalyse(false);

		playerData.SetIntVariables(genericTracker.GetIntVariables());
		playerData.SetFloatVariables(genericTracker.GetFloatVariables());
		playerData.SetKeyboardInput(keyboardTracker.GetKeyboardInput());
		playerData.SetMouseInput(mouseTracker.GetMouseInput());
	}

	public void StartAnalyse()
	{
		UserData calibrateData = DataStorage.GetCalibrateData();

		KeyboardAnalyser.CompareData(calibrateData, playerData);
		MouseAnalyser.CompareData(calibrateData, playerData);
		GenericAnalyser.CompareData(calibrateData, playerData);
	}

	public void StoreData()
	{
		DataStorage.StoreCalibrateData(playerData);
	}
}
