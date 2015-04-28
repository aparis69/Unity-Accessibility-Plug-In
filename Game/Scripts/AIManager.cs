using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour 
{
	public GameObject[] AI;

	void Start () 
	{
		AI = GameObject.FindGameObjectsWithTag("AI");
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			for (int i = 0 ; i < AI.Length ; i++)
				AI[i].GetComponent<AIController>().ActivateAI();
		}
	}
}
