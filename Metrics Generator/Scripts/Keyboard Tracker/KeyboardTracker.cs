using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardTracker : MonoBehaviour 
{
    public KeyboardAnalyser Analyser;
    public bool calibrationMode;

    static private KeyCode[] validKeyCodes;
    private List<KeyInput> keysInput;
    private bool analyserOn;

    void Start()
    {
        keysInput = new List<KeyInput>();

        if (validKeyCodes != null) return;
        validKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));

        analyserOn = false;
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
                    Analyser.CanAnalyse(true);
                    Analyser.SetPlayerKeyboardData(keysInput);
                }
            }

            return false;
        }

        return true;
    }
}
