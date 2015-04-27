using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardAnalyser : MonoBehaviour 
{	
    // Data retreived from the current player
    private List<KeyInput> keysInput;

    // Data retreived from the calibration files in CalibrationDataRead
    private List<KeyInput> averageKeyInputValues;

    // Result of the analysis
    private List<KeyInput> dataResult;

    // Other variables
    private bool canAnalyse;

	void Start () 
    {
        keysInput = new List<KeyInput>();
        dataResult = new List<KeyInput>();
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
        // Store the difference between the average values and the player values in dataResult list
        for (int i = 0 ; i < keysInput.Count ; i++)
        {
            KeyInput k = FindSimilarKeyInput(keysInput[i]);
            if(k != null)
                dataResult.Add(new KeyInput(k.GetKeyCode(), Mathf.Max(k.GetHitCount(), keysInput[i].GetHitCount()) - Mathf.Min(k.GetHitCount(), keysInput[i].GetHitCount()),
                                                            Mathf.Max(k.GetDoubleStrikingCount(), keysInput[i].GetDoubleStrikingCount()) - Mathf.Min(k.GetDoubleStrikingCount(), keysInput[i].GetDoubleStrikingCount())));
        }

        for (int i = 0; i < keysInput.Count; i++)
        {
            if (dataResult[i].GetDoubleStrikingCount() >= 3)
                Debug.Log("Problem with double strike on key : " + dataResult[i].GetKeyCode());
            if (dataResult[i].GetHitCount() >= 3)
                Debug.Log("Problem with hit count on key : " + dataResult[i].GetKeyCode());
        }

        canAnalyse = false;
    }

    private KeyInput FindSimilarKeyInput(KeyInput key)
    {
        for (int i = 0; i < averageKeyInputValues.Count; i++)
        {
            if (key.GetKeyCode() == averageKeyInputValues[i].GetKeyCode())
                return averageKeyInputValues[i];
        }

        return null;
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