using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericTracker : MonoBehaviour 
{
	public List<GenericVariableInformation> genericVariables;

	private List<GenericVariable<int>> intVariables;
	private List<GenericVariable<float>> floatVariables;
	private bool analyseOn;

	void Start () 
	{
		if (genericVariables == null)
			return;

		intVariables = new List<GenericVariable<int>>();
		floatVariables = new List<GenericVariable<float>>();

		for (int i = 0; i < genericVariables.Count; i++)
		{
			if(genericVariables[i].type == SupportedType.FLOAT)
				floatVariables.Add(new GenericVariable<float>(0f, genericVariables[i].VariableName, genericVariables[i].ClassName, genericVariables[i].GetMethodName));
			if (genericVariables[i].type == SupportedType.INT)
				intVariables.Add(new GenericVariable<int>(0, genericVariables[i].VariableName, genericVariables[i].ClassName, genericVariables[i].GetMethodName));
		}

		analyseOn = true;
	}

	void Update()
	{
		if (analyseOn)
		{
			for (int i = 0; i < intVariables.Count; i++)
			{
				intVariables[i].UpdateVariable();
				Debug.Log(intVariables[i].GetValue());
			}

			for (int i = 0; i < floatVariables.Count; i++)
			{
				floatVariables[i].UpdateVariable();
				Debug.Log(floatVariables[i].GetValue());
			}
		}
	}

	public void SetAnalyse(bool a)
	{
		analyseOn = a;
	}
}