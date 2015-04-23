using UnityEngine;
using System.Collections;

public class Point
{
    private float value;
    private int xPos;
    private int yPos;
    private float stepness;

    public Point()
    {

    }

    public Point(int x, int y, float value, float stepness)
    {
        this.xPos = x;
        this.yPos = y;
        this.value = value;
        this.stepness = stepness;
    }

    public void IncreaseValue()
    {
        value += stepness;
    }

    public int GetX()
    {
        return xPos;
    }

    public int GetY()
    {
        return yPos;
    }

    public float GetValue()
    {
        return value;
    }
}
