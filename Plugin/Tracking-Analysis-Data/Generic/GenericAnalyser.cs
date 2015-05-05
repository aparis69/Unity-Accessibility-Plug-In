using UnityEngine;
using System.Collections;

public class GenericAnalyser
{
	public static void CompareData(UserData calibrateData, UserData playerData)
	{
		// Int variables
		for (int i = 0; i < calibrateData.GetIntVariables().Count; i++)
		{
			if (Mathf.Abs(calibrateData.GetIntVariables()[i].GetValue() - playerData.GetIntVariables()[i].GetValue()) > 4)
				Debug.Log("The player might have a problem concerning " + calibrateData.GetIntVariables()[i].GetVariableName());
		}

		// Float variables
		for (int i = 0; i < calibrateData.GetFloatVariables().Count; i++)
		{
			if (Mathf.Abs(calibrateData.GetFloatVariables()[i].GetValue() - playerData.GetFloatVariables()[i].GetValue()) > 4)
				Debug.Log("The player might have a problem concerning " + calibrateData.GetFloatVariables()[i].GetVariableName());
		}
	}
}
