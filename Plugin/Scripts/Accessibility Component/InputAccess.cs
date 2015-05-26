using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputAccess
{
	private static bool doubleStrikingOption = false;
	private static bool mouseSensivityOption = true;
	private static float mouseSensivity = 1.0f;
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
				else
				{
					map[key] = Time.realtimeSinceStartup;
					return Input.GetKeyDown(key);
				}
			}
			else
			{
				map.Add(key, Time.realtimeSinceStartup);
				return Input.GetKeyDown(key);
			}
		}
		else
		{
			return Input.GetKeyDown(key);
		}
	}

	public static float GetAxis(string axisName)
	{
		if (mouseSensivityOption && axisName.Contains("Mouse"))
			return Input.GetAxis(axisName) * mouseSensivity;
		else
			return Input.GetAxis(axisName);
	}

	// Not implemented yet
	public static void GetKeyCombinaison(string combinationName)
	{

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

	public static void SetDoubleStrikingOption(bool db)
	{
		doubleStrikingOption = db;
	}

	public static void SetMouseSensivity(float sensivity)
	{
		mouseSensivity = sensivity;
	}
}