using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class MouseTrack : MonoBehaviour 
{
    private float[][] mousePositionArray;
    private List<float> mouseMovementsArray;

	void Start () 
    {   
        mousePositionArray = new float[Screen.width][];
        for (int i = 0; i < Screen.width; i++)
            mousePositionArray[i] = new float[Screen.height];

        mouseMovementsArray = new List<float>();
	}
	
	void Update () 
    {
        // Mouse Movements Track
        mouseMovementsArray.Add((Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))) / 2f * 50); 

        // Mouse Position Track
        if(Screen.width - (int)Input.mousePosition.x > 0 && Screen.width - (int)Input.mousePosition.x < Screen.width)
            if (Screen.height - (int)Input.mousePosition.y > 0 && Screen.height - (int)Input.mousePosition.y < Screen.height)
                mousePositionArray[Screen.width - (int)Input.mousePosition.x][Screen.height - (int)Input.mousePosition.y] = 1;
	}
}
