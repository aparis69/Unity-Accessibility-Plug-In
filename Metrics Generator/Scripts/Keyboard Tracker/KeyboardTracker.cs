using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardTracker : MonoBehaviour 
{
    public bool calibrationMode;

    private KeyboardAnalyser analyser;
    static private KeyCode[] validKeyCodes;
    private List<KeyInput> keysInput;
    private bool analyserOn;

    void Start()
    {
        analyser = (KeyboardAnalyser)GameObject.FindObjectOfType(typeof(KeyboardAnalyser));
        keysInput = new List<KeyInput>();
        analyserOn = false;

        if (validKeyCodes != null) 
            return;
        validKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
    }

    void Update()
    {
        if(CheckGameStatus())
        {
            KeyCode Key = FetchKey();
            bool isinlist = false;

            if (Key != KeyCode.None)
            {
                foreach (KeyInput KC in keysInput)
                {
                    if (Key == KC.GetKeyCode())
                    {
                        isinlist = true;
                        KC.IncreaseHit(Time.realtimeSinceStartup);
                    }
                }
                if (isinlist == false)
                {
                    KeyInput newKey = new KeyInput(Key);
                    newKey.IncreaseHit(Time.realtimeSinceStartup);
                    keysInput.Add(newKey);
                }
            }
        }    
    }

    private KeyCode FetchKey()
    {
        int e = validKeyCodes.Length;
        for (int i = 0; i < e; i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
            {
                return (KeyCode)i;
            }
        }

        return KeyCode.None;
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
                    CalibrationDataStorage.StoreKeyboardInput(keysInput, calibrationMode);
                }
                else
                {
                    analyser.CanAnalyse(true);
                    analyser.SetPlayerKeyboardData(keysInput);
                }
            }

            return false;
        }

        return true;
    }
}
