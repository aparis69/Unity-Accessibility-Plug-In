using UnityEngine;
using System.Collections;

public class UserData
{
	private KeyboardInput keyboardInput;
	private MouseInput mouseInput;

	public UserData()
	{
		keyboardInput = new KeyboardInput();
		mouseInput = new MouseInput();
	}

	public void SetKeyboardInput(KeyboardInput kbi)
	{
		keyboardInput = kbi;
	}

	public void SetMouseInput(MouseInput mi)
	{
		mouseInput = mi;
	}

	public KeyboardInput GetKeyboardInput()
	{
		return keyboardInput;
	}

	public MouseInput GetMouseInput()
	{
		return mouseInput;
	}
}