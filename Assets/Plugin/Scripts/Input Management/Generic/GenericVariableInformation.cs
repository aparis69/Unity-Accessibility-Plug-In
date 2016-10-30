using UnityEngine;
 using UnityEditor;
using System.Collections;

[System.Serializable]
public class GenericVariableInformation 
{
	[Header("Required")]
	public string VariableName;
	public string ClassName;
	public string GetMethodName;
	public SupportedType type;
	[Header("Optional")]
	public string SetMethodName;
}

public enum SupportedType
{
	FLOAT,
	INT,
};