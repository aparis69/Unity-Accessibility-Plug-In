using UnityEngine;
using System.Collections;

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
