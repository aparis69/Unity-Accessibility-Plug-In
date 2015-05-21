using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericTracker : MonoBehaviour 
{
	public List<GenericVariableInformation> genericVariables;

	private List<GenericVariable<int>> intVariables;
	private List<GenericVariable<float>> floatVariables;
	private bool analyseEnabled;

	void Start () 
	{
		if (genericVariables == null)
			return;

		intVariables = new List<GenericVariable<int>>();
		floatVariables = new List<GenericVariable<float>>();

		for (int i = 0; i < genericVariables.Count; i++)
		{
			if(genericVariables[i].type == SupportedType.FLOAT)
				floatVariables.Add(new GenericVariable<float>(0f, genericVariables[i].VariableName, genericVariables[i].ClassName, genericVariables[i].GetMethodName, genericVariables[i].SetMethodName));
			if (genericVariables[i].type == SupportedType.INT)
				intVariables.Add(new GenericVariable<int>(0, genericVariables[i].VariableName, genericVariables[i].ClassName, genericVariables[i].GetMethodName, genericVariables[i].SetMethodName));
		}

		analyseEnabled = true;
	}

	void Update()
	{
		if (analyseEnabled)
		{
			for (int i = 0; i < intVariables.Count; i++)
				intVariables[i].UpdateVariable();
			for (int i = 0; i < floatVariables.Count; i++)
				floatVariables[i].UpdateVariable();
		}
	}

	public void SetAnalyse(bool a)
	{
		analyseEnabled = a;
	}

	public List<GenericVariable<int>> GetIntVariables()
	{
		return intVariables;
	}

	public List<GenericVariable<float>> GetFloatVariables()
	{
		return floatVariables;
	}
}