using UnityEngine;
using System.Collections;

[System.Serializable]
public class GenericVariableInformation 
{
	public string VariableName;
	public string ClassName;
	public string GetMethodName;
	public SupportedType type;
}

public enum SupportedType
{
	FLOAT,
	INT,
};