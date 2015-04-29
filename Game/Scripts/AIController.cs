using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour 
{
    public GameObject goal;
    private NavMeshAgent navMesh;

	void Start () 
    {
        navMesh = this.GetComponent<NavMeshAgent>();
	}
	
	void Update () 
    {
	    
	}

	public void ActivateAI()
	{
		navMesh.destination = goal.transform.position;
	}
}
