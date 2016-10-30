using UnityEngine;
using System.Collections;

/// <summary>
/// Class that handles the events in the first scene called "Main Menu"
/// In analysis mode, at the end of the game, by hitting "o", the game will stop and the accessibility plug in will tell the player if he has a problem or not.
/// In calibration mode, at the end of the game, the data is stored into text file to be then used as calibrate data for analysis future potential disabilities.
/// </summary>
public class MenuEvents : MonoBehaviour
{
	public void OnAnalyseButtonMenu()
	{
		PlayerPrefs.SetInt("CalibrationMode", 1);
		Application.LoadLevel("Game");
	}

	public void OnCalibrateButtonMenu()
	{
		PlayerPrefs.SetInt("CalibrationMode", 0);
		Application.LoadLevel("Game");
	}
}
