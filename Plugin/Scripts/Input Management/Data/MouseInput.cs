using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseInput
{
	private List<Vector2> mousePointerPosition;
    private List<float> mouseMovementsList;
	private List<string> mouseButtonClicks;
    private List<MouseKeyInput> mouseKeyList;
	private int jitteringCount;

	public MouseInput()
	{
		mousePointerPosition = new List<Vector2>();
        mouseMovementsList = new List<float>();
		mouseButtonClicks = new List<string>();
        mouseKeyList = new List<MouseKeyInput>();       
	}

	public void AddMousePointerPosition(Vector2 pos)
	{
		mousePointerPosition.Add(pos);
	}

    public void AddMouseMovement(float mov)
    {
        mouseMovementsList.Add(mov);
    }

	public void AddMouseButtonClick(string click)
	{
		mouseButtonClicks.Add(click);
	}

	public void SetMousePointerPosition(List<Vector2> list)
	{
		mousePointerPosition = list;
	}

    public List<Vector2> getMousePointerPosition()
    {
        return this.mousePointerPosition;
    }

    public List<float> getMouseMovementsList()
    {
        return this.mouseMovementsList;
    }

    public List<string> getMouseButtonClicks()
    {
        return this.mouseButtonClicks;
    }

    public void addMouseKeyList(List<MouseKeyInput> _MKI)
    {
        this.mouseKeyList = _MKI;
    }

    public List<MouseKeyInput> getMouseKeyList()
    {
        return this.mouseKeyList;
    }

	public void SetJitteringCount(int j)
	{
		jitteringCount = j;
	}

	public int GetJitteringCount()
	{
		return jitteringCount;
	}
}
