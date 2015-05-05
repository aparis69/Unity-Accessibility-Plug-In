using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataStorage : MonoBehaviour
{
	// Read
	public static UserData GetCalibrateData()
	{
		// This UserData contains average key input values and average jittering count, but no information about the mouse position or the mouse click
		UserData finalCalibrateData = new UserData();

		// KEYBOARD DATA
		int numberOfFile = 0;
		do
		{
			if (System.IO.File.Exists("./Data/Calibration/Keyboard Inputs/Keyboard" + numberOfFile.ToString() + ".txt"))
				numberOfFile++;
			else
				break;
		} while (true);

		List<UserData> usersData = new List<UserData>();
		for (int i = 0; i < numberOfFile; i++)
		{
			UserData user = new UserData();
			List<KeyInput> keys = new List<KeyInput>();
			string[] lines = System.IO.File.ReadAllLines("./Data/Calibration/Keyboard Inputs/Keyboard" + i.ToString() + ".txt");

			foreach (string line in lines)
			{
				string[] words = line.Split(',');
				KeyInput k = new KeyInput((KeyCode)System.Enum.Parse(typeof(KeyCode), words[0]));
				int hit = 0;
				int.TryParse(words[1], out hit);
				int doubleStrike = 0;
				int.TryParse(words[2], out doubleStrike);

				// Store the values
				k.SetHitCount(hit);
				k.SetDoubleStrikingCount(doubleStrike);
				user.GetKeyboardInput().AddKeyInput(k);
			}

			usersData.Add(user);
		}

		finalCalibrateData.GetKeyboardInput().SetKeyInput(GetAverageKeyInputValues(usersData));


		// MOUSE POSITION DATA
		numberOfFile = 0;
		do
		{
			if (System.IO.File.Exists("./Data/Calibration/Mouse Positions/MousePositions" + numberOfFile.ToString() + ".txt"))
				numberOfFile++;
			else
				break;
		} while (true);

		usersData = new List<UserData>();
		for (int i = 0; i < numberOfFile; i++)
		{
			UserData user = new UserData();
			string[] lines = System.IO.File.ReadAllLines("./Data/Calibration/Mouse Positions/MousePositions" + i.ToString() + ".txt");

			foreach (string line in lines)
			{
				string[] words = line.Split(',');

				if (words[0] == "Jittering")
				{
					int ji;
					int.TryParse(words[1], out ji);
					user.GetMouseInput().SetJitteringCount(ji);
				}
				else
				{
					float x, y;
					float.TryParse(words[0], out x);
					float.TryParse(words[1], out y);

					Vector2 vec = new Vector2(x, y);

					user.GetMouseInput().AddMousePointerPosition(vec);
				}
			}

			usersData.Add(user);
		}
		// Set the average jittering count
		finalCalibrateData.GetMouseInput().SetJitteringCount(GetAverageJitteringCount(usersData));

		return finalCalibrateData;
	}

	private static int GetAverageJitteringCount(List<UserData> usersData)
	{
		int totalJittering = 0;
		foreach (UserData user in usersData)
		{
			totalJittering += user.GetMouseInput().GetJitteringCount();
		}

		return totalJittering / usersData.Count;
	}

	private static List<KeyInput> GetAverageKeyInputValues(List<UserData> usersData)
	{
		List<KeyInput> averageKeyInputValue = new List<KeyInput>();

		for (int i = 0; i < usersData.Count; i++)
		{
			foreach (KeyInput key in usersData[i].GetKeyboardInput().GetKeyInput())
			{
				bool isinlist = false;

				foreach (KeyInput k in averageKeyInputValue)
				{
					// If keycode already exist in the list, we sum the hit counts and occurences count
					if (key.GetKeyCode() == k.GetKeyCode())
					{
						k.SetOccurences(k.GetOccurences() + 1);
						k.SetHitCount(k.GetHitCount() + key.GetHitCount());
						k.SetDoubleStrikingCount(k.GetDoubleStrikingCount() + key.GetDoubleStrikingCount());
						isinlist = true;
					}
				}
				// if keycode does not exist, we add it to the list
				if (!isinlist)
				{
					key.SetOccurences(1);
					averageKeyInputValue.Add(key);
				}
			}
		}

		foreach (KeyInput k in averageKeyInputValue)
		{
			k.SetHitCount(k.GetHitCount() / k.GetOccurences());
			k.SetDoubleStrikingCount(k.GetDoubleStrikingCount() / k.GetOccurences());
		}

		return averageKeyInputValue;
	}

	private static GenericVariable<int> GetAverageIntVariables(int index)
	{
		return null;
	}

	// Storage
	public static void StoreCalibrateData(UserData data)
	{
		// Keyboard input storage
		List<string> keyboardInputStrings = new List<string>();
		foreach (KeyInput KC in data.GetKeyboardInput().GetKeyInput())
			keyboardInputStrings.Add(KC.GetKeyCode().ToString() + "," + KC.GetHitCount().ToString() + "," + KC.GetDoubleStrikingCount().ToString());
		// Determine a new name for the future file
		int i = 0;
		do
		{
			if (!System.IO.File.Exists("./Data/Calibration/Keyboard Inputs/Keyboard" + i.ToString() + ".txt"))
				break;
			i++;
		} while (true);
		// Create the file
		System.IO.File.WriteAllLines("./Data/Calibration/Keyboard Inputs/Keyboard" + i.ToString() + ".txt", keyboardInputStrings.ToArray());


		// Mouse pointer position Storage
		List<string> mousePositionsStrings = new List<string>();	
		// Add the jittering count at the beginning of the file
		mousePositionsStrings.Add(CalculateJitteringCount(data));
		foreach (Vector2 vec in data.GetMouseInput().getMousePointerPosition())
			mousePositionsStrings.Add(vec.x + "," + vec.y);
		// Determine a new name for the future file
		i = 0;
		do
		{
			if (!System.IO.File.Exists("./Data/Calibration/Mouse Positions/MousePositions" + i.ToString() + ".txt"))
				break;
			i++;
		} while (true);
		// Create the file
		System.IO.File.WriteAllLines("./Data/Calibration/Mouse Positions/MousePositions" + i.ToString() + ".txt", mousePositionsStrings.ToArray());


		// Mouse button click storage
		List<string> mouseClicksStrings = new List<string>();
		mouseClicksStrings.Add("Left clicks : " + data.GetMouseInput().getMouseKeyList()[0].getCount());
		mouseClicksStrings.Add("Right clicks : " + data.GetMouseInput().getMouseKeyList()[1].getCount());
		mouseClicksStrings.Add("Middle clicks : " + data.GetMouseInput().getMouseKeyList()[2].getCount());
		// Determine a new name for the future file
		i = 0;
		do
		{
			if (!System.IO.File.Exists("./Data/Calibration/Mouse Clicks/MouseClicks" + i.ToString() + ".txt"))
				break;
			i++;
		} while (true);
		// Create the file
		System.IO.File.WriteAllLines("./Data/Calibration/Mouse Clicks/MouseClicks" + i.ToString() + ".txt", mouseClicksStrings.ToArray());


		// Generic data storage
		// int
		for (i = 0; i < data.GetIntVariables().Count; i++)
		{
			int j = 0;
			do
			{
				if (!System.IO.File.Exists("./Data/Calibration/Generic/" + data.GetIntVariables()[i].GetVariableName() + j.ToString() + ".txt"))
					break;
				j++;
			} while (true);

			List<string> lines = new List<string>();
			lines.Add(data.GetIntVariables()[i].GetValue().ToString());
			System.IO.File.WriteAllLines("./Data/Calibration/Generic/" + data.GetIntVariables()[i].GetVariableName() + j.ToString() + ".txt", lines.ToArray());
		}
		// float
		for (i = 0; i < data.GetFloatVariables().Count; i++)
		{
			int j = 0;
			do
			{
				if (!System.IO.File.Exists("./Data/Calibration/Generic/" + data.GetFloatVariables()[i].GetVariableName() + j.ToString() + ".txt"))
					break;
				j++;
			} while (true);

			List<string> lines = new List<string>();
			lines.Add(data.GetFloatVariables()[i].GetValue().ToString());
			System.IO.File.WriteAllLines("./Data/Calibration/Generic/" + data.GetFloatVariables()[i].GetVariableName() + j.ToString() + ".txt", lines.ToArray());
		}
	}

	private static string CalculateJitteringCount(UserData data)
	{
		return "Jittering, " + MouseAnalyser.CountQuickMouseDirectionChanges(data.GetMouseInput().getMousePointerPosition());
	}
}