using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class MouseTracker : MonoBehaviour 
{
    public bool calibrationMode;

    private MouseAnalyser analyser;
    private List<float> mouseMovementsList;
    private List<Vector2> mousePointerPosition;
    private bool analyserOn;

	void Start () 
    {
        analyser = (MouseAnalyser)GameObject.FindObjectOfType(typeof(MouseAnalyser));

        mouseMovementsList = new List<float>();
        mousePointerPosition = new List<Vector2>();      
	}
	
	void Update () 
    {
        if(CheckGameStatus())
        {
            // Mouse Movements Track
            mouseMovementsList.Add((Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))) / 2f * 50);

            // Mouse Position Track
            if (Screen.width - (int)Input.mousePosition.x > 0 && Screen.width - (int)Input.mousePosition.x < Screen.width) //if mouse is in the screen
                if (Screen.height - (int)Input.mousePosition.y > 0 && Screen.height - (int)Input.mousePosition.y < Screen.height) //if mouse is in the screen
                    mousePointerPosition.Add(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }     
    }

    public List<float> GetMouseMovementsList()
    {
        return mouseMovementsList;
    }

    bool CheckGameStatus()
    {
        int status = PlayerPrefs.GetInt("Game off");

        if (status == 1)
        {
            if (!analyserOn)
            {
                analyserOn = true;

                // if calibration mode not activated, analyse the current player data
                if (calibrationMode)
                {
                    CalibrationDataStorage.StoreMousePositionFromList(mousePointerPosition, calibrationMode);
                }
                else
                {
                    analyser.CanAnalyse(true);
                    analyser.SetMousePositionFromPlayer(mousePointerPosition);
                }
            }

            return false;
        }

        return true;
    }
}