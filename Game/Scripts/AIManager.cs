using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour 
{
	private GameObject[] AI;
	private GameObject[] scaredAI;
	private bool AIenabled;

	void Start () 
	{
		AI = GameObject.FindGameObjectsWithTag("AI");
		scaredAI = GameObject.FindGameObjectsWithTag("Scared AI");

		for (int i = 0; i < scaredAI.Length; i++)
			scaredAI[i].SetActive(false);

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

				for (int i = 0; i < scaredAI.Length; i++)
					scaredAI[i].SetActive(true);
			}
			else
			{
				for (int i = 0; i < AI.Length; i++)
					AI[i].GetComponent<AIController>().DesactiveAI();
				AIenabled = false;

				for (int i = 0; i < scaredAI.Length; i++)
					scaredAI[i].SetActive(false);
			}
		}
	}
}