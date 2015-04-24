using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class MouseTracker : MonoBehaviour 
{
    public bool calibrationMode;

    private float[][] mousePositionArray;
    private List<float> mouseMovementsList;

	void Start () 
    {
        mousePositionArray = new float[Screen.width][];
        for (int i = 0; i < Screen.width; i++)
            mousePositionArray[i] = new float[Screen.height];

        for (int i = 0; i < Screen.width; i++)
            for (int j = 0; j < Screen.height; j++)
                mousePositionArray[i][j] = 0;

        mouseMovementsList = new List<float>();
	}
	
	void Update () 
    {
        // Mouse Movements Track
        mouseMovementsList.Add((Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))) / 2f * 50); 

        // Mouse Position Track
        if(Screen.width - (int)Input.mousePosition.x > 0 && Screen.width - (int)Input.mousePosition.x < Screen.width)
            if (Screen.height - (int)Input.mousePosition.y > 0 && Screen.height - (int)Input.mousePosition.y < Screen.height)
                mousePositionArray[Screen.width - (int)Input.mousePosition.x][Screen.height - (int)Input.mousePosition.y] += 0.1f;
    }

    void OnDestroy()
    {
        // Store the data retreived during the game
        CalibrationDataStorage.StoreMouseMovements(mouseMovementsList, calibrationMode);
        CalibrationDataStorage.StoreMousePositionFromArray(mousePositionArray, calibrationMode);
    }

    public float[][] GetMousePositionArray()
    {
        return mousePositionArray;
    }

    public List<float> GetMouseMovementsList()
    {
        return mouseMovementsList;
    }
}