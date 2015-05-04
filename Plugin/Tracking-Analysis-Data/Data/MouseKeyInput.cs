using UnityEngine;
using System.Collections;

public class MouseKeyInput 
{
    private string type;
    private int count;

    public MouseKeyInput(string type)
    {
        this.type = type;
        count = 0;
    }

    public string getType()
    {
        return this.type;
    }

    public int getCount()
    {
        return this.count;
    }

    public void setCount(int count)
    {
        this.count = count;
    }

    public void incrementCount()
    {
        this.count++;
    }
}
