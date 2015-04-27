using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseAnalyser : MonoBehaviour
{
    // Mouse Position analysing
    // Data retreived from calibration, can use only the first index or the whole List<>
    private List<UserData> mPositionCalibrationData;

    // Data retreived from the player during the game
    private List<Vector2> mPositionPlayer;


    // Other variables
    private bool canAnalyse;

	void Start () 
    {
        mPositionPlayer = new List<Vector2>();
        mPositionCalibrationData = CalibrationDataRead.GetMousePositionData();
        canAnalyse = false;
	}
	
	void Update () 
    {
	    if(canAnalyse)
        {
            CompareData();
            canAnalyse = false;
        }
	}

    private void CompareData()
    {

    }

    public void SetMousePositionFromPlayer(List<Vector2> mPlayer)
    {
        mPositionPlayer = mPlayer;
    }

    public void CanAnalyse(bool can)
    {
        canAnalyse = can;
    }
}
