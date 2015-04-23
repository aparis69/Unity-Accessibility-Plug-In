using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardTracker : MonoBehaviour 
{
    static private KeyCode[] validKeyCodes;
    private string logger;
    private List<KeyCode> _KCList;
    private List<int> _KCNum;

    private void validKC()
    {
        if (validKeyCodes != null) return;
        validKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
    }

	void Start () 
    {
        validKC();
        logger = "";
        _KCList = new List<KeyCode>();
        _KCNum = new List<int>();
	}
	
	void Update () 
    {
        KeyCode Key = FetchKey();
        bool isinlist = false;
        if (Key != KeyCode.None)
        {
            logger += Key.ToString();
            foreach(KeyCode KC in _KCList)
            {
                if(Key == KC)
                {
                    isinlist = true;                    
                    _KCNum[_KCList.IndexOf(KC)]++;
                }                                    
            }
            if(isinlist == false)
            {
                _KCList.Add(Key);
                _KCNum.Add(1);
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

    void OnDestroy()
    {
        Debug.Log(logger);
        foreach(KeyCode KC in _KCList)
        {
            Debug.Log("Key: " + KC.ToString() + " Count: " + _KCNum[_KCList.IndexOf(KC)]);
        }
    }
}
