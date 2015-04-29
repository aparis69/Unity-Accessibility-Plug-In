using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseInput
{
	private List<Vector2> mousePointerPosition;
	private List<int> mouseButtonClicks;
	private List<int> mouseClickCount;

	public MouseInput()
	{
		mousePointerPosition = new List<Vector2>();
		mouseButtonClicks = new List<int>();
		mouseClickCount = new List<int>();
	}

	public void AddMousePointerPosition(Vector2 pos)
	{
		mousePointerPosition.Add(pos);
	}

	public void AddMouseButtonClicks(int click)
	{
		mouseButtonClicks.Add(click);
	}

	public void IncreaseMouseClickCount()
	{
		//mouse
	}
}
