using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputAccess
{
	private static bool doubleStrikingOption = false;
	private static bool mouseSensivityOption = false;
	private static Dictionary<KeyCode, float> map;
	private static KeyCode[] keys = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));

	public static bool GetKeyDown(KeyCode key)
	{
		if (doubleStrikingOption)
		{
			if (map.ContainsKey(key))
			{
				float timing = map[key];
				if (Time.realtimeSinceStartup - timing > 0.5f)
					return false;
			}

			return Input.GetKeyDown(key);
		}
		else
		{
			return Input.GetKeyDown(key);
		}
	}

	public static float GetAxis(string axisName)
	{
		if (mouseSensivityOption)
			return Input.GetAxis(axisName) / 2f;
		else
			return Input.GetAxis(axisName);
	}

	// Getter & Setter
	public static bool DoubleStrikingOptionEnabled()
	{
		return doubleStrikingOption;
	}

	public static bool MouseSensivityOptionEnabled()
	{
		return mouseSensivityOption;
	}
}
