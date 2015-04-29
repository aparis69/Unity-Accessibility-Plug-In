using UnityEngine;
using System.Collections;

public class KeyboardTracker : MonoBehaviour 
{
	private static KeyCode[] validKeyCodes;
	private KeyboardInput keyboardInput;

	void Start () 
	{
		keyboardInput = new KeyboardInput();

		// Intializing static member
		if (validKeyCodes != null)
			return;
		validKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
	}
	
	void Update () 
	{
		KeyCode keyDown = FetchKey();

		if (keyDown != KeyCode.None)
		{
			KeyInput similarKey = keyboardInput.GetExistingKeyInput(keyDown);

			if (similarKey != null)
				similarKey.IncreaseHitCount(Time.realtimeSinceStartup);
			else
				keyboardInput.AddKeyInput(new KeyInput(keyDown, 0, 0));
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

	public void SetKeyboardInput(KeyboardInput kbi)
	{
		keyboardInput = kbi;
	}

	public KeyboardInput GetKeyboardInput()
	{
		return keyboardInput;
	}
}
