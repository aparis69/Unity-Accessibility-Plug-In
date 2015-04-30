using UnityEngine;
using System.Collections;

public class KeyboardTracker : MonoBehaviour 
{
	private static KeyCode[] validKeyCodes;
	private KeyboardInput keyboardInput;

	private bool analyseEnabled;

	void Start () 
	{
		keyboardInput = new KeyboardInput();
		analyseEnabled = true;

		// Intializing static member
		if (validKeyCodes != null)
			return;
		validKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
	}
	
	void Update () 
	{
		if (analyseEnabled)
		{
			KeyCode keyDown = FetchKey();

			if (keyDown != KeyCode.None)
			{
				KeyInput similarKey = keyboardInput.GetExistingKeyInput(keyDown);

				if (similarKey != null)
					similarKey.IncreaseHitCount(Time.realtimeSinceStartup);
				else
					keyboardInput.AddKeyInput(new KeyInput(keyDown, 1, 0));
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

	public void SetKeyboardInput(KeyboardInput kbi)
	{
		keyboardInput = kbi;
	}

	public KeyboardInput GetKeyboardInput()
	{
		return keyboardInput;
	}

	public void SetAnalyse(bool a)
	{
		analyseEnabled = a;
	}
}
