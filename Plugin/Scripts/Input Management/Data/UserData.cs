using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData
{
	private KeyboardInput keyboardInput;
	private MouseInput mouseInput;
	private List<GenericVariable<int>> intVariables;
	private List<GenericVariable<float>> floatVariables;

	public UserData()
	{
		keyboardInput = new KeyboardInput();
		mouseInput = new MouseInput();
		intVariables = new List<GenericVariable<int>>();
		floatVariables = new List<GenericVariable<float>>();
	}

	public void SetKeyboardInput(KeyboardInput kbi)
	{
		keyboardInput = kbi;
	}

	public void SetMouseInput(MouseInput mi)
	{
		mouseInput = mi;
	}

	public void SetIntVariables(List<GenericVariable<int>> intvariables)
	{
		intVariables = intvariables;
	}

	public void SetFloatVariables(List<GenericVariable<float>> floatvariables)
	{
		floatVariables = floatvariables;
	}

	public KeyboardInput GetKeyboardInput()
	{
		return keyboardInput;
	}

	public MouseInput GetMouseInput()
	{
		return mouseInput;
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