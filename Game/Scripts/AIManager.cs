using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour 
{
	private GameObject[] AI;
	private bool AIenabled;

	void Start () 
	{
		AI = GameObject.FindGameObjectsWithTag("AI");
		AIenabled = false;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			if (!AIenabled)
			{
				for (int i = 0; i < AI.Length; i++)
					AI[i].GetComponent<AIController>().ActivateAI();
				AIenabled = true;
			}
			else
			{
				for (int i = 0; i < AI.Length; i++)
					AI[i].GetComponent<AIController>().DesactiveAI();
				AIenabled = false;
			}
		}
	}
}
