using UnityEngine;
using System;
using System.Reflection;

public class GenericVariable<T> where T : struct
{
	// Developer parameters
	private string variableName;
	private string className;
	private string getMethodName;
	private T value;

	// Plug in necessary variables
	private Type type;
	private UnityEngine.Object gameObject;
	private MethodInfo methodInfo;

	public GenericVariable()
	{
	}

	public GenericVariable(T initialValue, string variableName, string className, string methodName)
	{
		// Initialization exception handling
		if (!(initialValue is float) && !(initialValue is int))
			throw new Exception("Type supported : int, float");
		if (variableName == null || className == null || methodName == null)
			throw new ArgumentNullException("Check your parameters");

		this.variableName = variableName;
		this.className = className;
		this.getMethodName = methodName;
		this.value = initialValue;

		type = Type.GetType(className);
		gameObject = GameObject.FindObjectOfType(type);
		methodInfo = type.GetMethod(getMethodName);

		if (gameObject == null)
			throw new Exception("Target null, check your GameObject name");
	}

	public GenericVariable(T value, string variableName)
	{
		// Initialization exception handling
		if (!(value is float) && !(value is int))
			throw new Exception("Type supported : int, float");
		if (variableName == null)
			throw new ArgumentNullException("Check your parameters");

		this.value = value;
	}

	public void UpdateVariable()
	{
		try
		{
			value = (T)methodInfo.Invoke(gameObject, null);
		}
		catch (TargetException ex)
		{
			Debug.Log("Target is null : " + ex.Message);
		}
		catch (ArgumentException ex)
		{
			Debug.Log("Arguments does not match : " + ex.Message);
		}
		catch (TargetInvocationException ex)
		{
			Debug.Log("Target method throw an exception : " + ex.Message);
		}
		catch (TargetParameterCountException ex)
		{
			Debug.Log("Target paramaters count does not match : " + ex.Message);
		}
		catch (MethodAccessException ex)
		{
			Debug.Log("The caller does not have permission : " + ex.Message);
		}
		catch (InvalidOperationException ex)
		{
			Debug.Log("The type that declares the method is an open generic type : " + ex.Message);
		}
		catch (NotSupportedException ex)
		{
			Debug.Log(ex.Message);
		}
	}

	public string GetVariableName()
	{
		return variableName;
	}

	public T GetValue()
	{
		return value;
	}
}