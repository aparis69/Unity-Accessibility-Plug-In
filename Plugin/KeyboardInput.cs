using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardInput 
{
	List<KeyInput> inputs;

	public KeyboardInput()
	{
		inputs = new List<KeyInput>();
	}

	public void AddKeyInput(KeyInput newKey)
	{
		inputs.Add(newKey);
	}

	public KeyInput GetExistingKeyInput(KeyCode code)
	{
		foreach (KeyInput KC in inputs)
		{
			if (code == KC.GetKeyCode())
				return KC;
		}

		return null;
	}

	public List<KeyInput> GetKeyInput()
	{
		return inputs;
	}

	public int GetKeyInputCount()
	{
		return inputs.Count;
	}
}