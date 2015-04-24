using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardAnalyser : MonoBehaviour 
{	
    // Data retreived from the current player
    private List<KeyInput> keysInput;

    // Data retreived from the calibration files in CalibrationDataRead
    private List<KeyInput> averageKeyInputValues;

    // Other variables
    private bool canAnalyse;

	void Start () 
    {
        averageKeyInputValues = CalibrationDataRead.GetKeyboardData();
        canAnalyse = false;
	}
		
	void Update ()
    {
	    if(canAnalyse)
        {
            CompareData();
        }
	}

    private void CompareData()
    {
        for (int i = 0 ; i < keysInput.Count ; i++)
        {
            // Must compare every similar key input in keysInput and averageKeyInputValues and decide if the player has a problem or not :
            // -the player is not using the right keys
            // -the player is double striking to much
        }
    }

    public void SetPlayerKeyboardData(List<KeyInput> playerKeysInput)
    {
        this.keysInput = playerKeysInput;
    }

    public void CanAnalyse(bool can)
    {
        canAnalyse = can;
    }
}