using UnityEngine;
using System.Collections;
	
public class PluginManager : MonoBehaviour 
{
	private bool calibrationMode;
	private InputManagement inputManagement;

	void Start ()
	{
		inputManagement = this.GetComponent<InputManagement>();

		if (PlayerPrefs.GetInt("CalibrationMode") == 1)
			calibrationMode = false;
		else
			calibrationMode = true;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			inputManagement.SetData();

			// Calibration : storage
			if (calibrationMode)
				inputManagement.StoreData();
			// Analysis : get the calibrate data back, and compare
			else
				inputManagement.StartAnalyse();
		}
	}
}