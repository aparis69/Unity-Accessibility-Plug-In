using UnityEngine;
using System.Collections;

public class KeyboardAnalyser 
{
	public static void CompareData(UserData calibrateData, UserData playerData)
	{
		UserData dataResult = new UserData();

		// Store the difference between the average values and the player values in dataResult list
		for (int i = 0; i < playerData.GetKeyboardInput().GetKeyInputCount() ; i++)
		{
			KeyInput playerKey = playerData.GetKeyboardInput().GetKeyInput()[i];
			KeyInput k = calibrateData.GetKeyboardInput().GetExistingKeyInput(playerKey.GetKeyCode());
			if (k != null)
				dataResult.GetKeyboardInput().AddKeyInput(new KeyInput(k.GetKeyCode(), Mathf.Max(k.GetHitCount(), playerKey.GetHitCount()) - Mathf.Min(k.GetHitCount(), playerKey.GetHitCount()),
															Mathf.Max(k.GetDoubleStrikingCount(), playerKey.GetDoubleStrikingCount()) - Mathf.Min(k.GetDoubleStrikingCount(), playerKey.GetDoubleStrikingCount())));
		}

		// Tell the player if there is a problem or not
		for (int i = 0; i < dataResult.GetKeyboardInput().GetKeyInputCount() ; i++)
		{
			KeyInput key = dataResult.GetKeyboardInput().GetKeyInput()[i];

			if (key.GetDoubleStrikingCount() >= 5 && InputAccess.DoubleStrikingOptionEnabled() == false)
				Debug.Log("Player had trouble using the keyboard correctly. Unusual double striking was detected on the key : " + key.GetKeyCode());
			if (key.GetHitCount() >= 5)
				Debug.Log("Player had trouble using the keyboard correctly. Unusual hit count was detected on the key : " + key.GetKeyCode());
		}
	}
}