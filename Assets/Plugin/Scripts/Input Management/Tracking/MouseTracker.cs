using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class MouseTracker : MonoBehaviour
{
    private MouseKeyInput left, right, middle;
    private MouseInput _MouseInput;

	private bool analyseEnabled;
	
    void Start()
    {
		_MouseInput = new MouseInput();

        left = new MouseKeyInput("Left Button");
        right = new MouseKeyInput("Right Button");
        middle = new MouseKeyInput("Middle Button");

		analyseEnabled = true;
    }

    void Update()
    {
		if (analyseEnabled)
		{
			// Mouse Position Track
			if (Screen.width - (int)Input.mousePosition.x > 0 && Screen.width - (int)Input.mousePosition.x < Screen.width) //if mouse is in the screen
				if (Screen.height - (int)Input.mousePosition.y > 0 && Screen.height - (int)Input.mousePosition.y < Screen.height) //if mouse is in the screen
					_MouseInput.AddMousePointerPosition(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

			// Mouse Button Clicking
			if (Input.GetMouseButtonDown(0)) //left click
			{
				_MouseInput.AddMouseButtonClick("Left Button");
				left.incrementCount();
			}
			if (Input.GetMouseButtonDown(1)) //right click
			{
				_MouseInput.AddMouseButtonClick("Right Button");
				right.incrementCount();
			}
			if (Input.GetMouseButtonDown(2)) //middle click
			{
				_MouseInput.AddMouseButtonClick("Middle Button");
				middle.incrementCount();
			}      
		}
    }

	public MouseInput GetMouseInput()
	{
		List<MouseKeyInput> _MKI = new List<MouseKeyInput>();
		_MKI.Add(left);
		_MKI.Add(right);
		_MKI.Add(middle);
		_MouseInput.addMouseKeyList(_MKI);

		return _MouseInput;
	}

	public void SetAnalyse(bool a)
	{
		analyseEnabled = a;
	}
}