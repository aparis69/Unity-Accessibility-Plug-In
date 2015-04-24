using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardAnalyser : MonoBehaviour 
{	
    // Data retreived from the current player
    private List<KeyInput> keysInput;

    // Data retreived from the calibration files
    private List<KeyInput> averageKeyInputValues;

    // Other variables
    private bool canAnalyse;

	void Start () 
    {
        averageKeyInputValues = CalibrationData.GetKeyboardData();
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