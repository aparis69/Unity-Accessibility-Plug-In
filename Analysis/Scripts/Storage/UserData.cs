using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData 
{
    private List<KeyInput> userInputs;
    private List<Vector2> userMousePositions;

    public UserData()
    {
        userMousePositions = new List<Vector2>();
        userInputs = new List<KeyInput>();
    }

    public UserData(List<KeyInput> lk)
    {
        userInputs = lk;
    }

    public void AddKeyInput(KeyInput key)
    {
        userInputs.Add(key);
    }

    public List<KeyInput> GetKeyInput()
    {
        return userInputs;
    }

    public void AddMousePosition(Vector2 pos)
    {
        userMousePositions.Add(pos);
    }

    public List<Vector2> GetMousePositions()
    {
        return userMousePositions;
    }
}
