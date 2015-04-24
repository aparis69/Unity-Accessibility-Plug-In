using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData 
{
    private List<KeyInput> userInputs;

    public UserData()
    {

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
}
