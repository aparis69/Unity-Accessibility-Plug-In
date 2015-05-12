using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabPeople : MonoBehaviour 
{
	private bool grabModeEnabled;
	private List<GameObject> AIInventory;

	void Start () 
	{
		grabModeEnabled = false;
		AIInventory = new List<GameObject>();
	}

	void Update () 
	{
		if (Input.GetMouseButton(0))
		{
			grabModeEnabled = true;
		}
		else
		{
			grabModeEnabled = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// If the player wants to grab an AI Controller
		if (other.gameObject.tag == "Scared AI" && grabModeEnabled)
		{
			// We add it into his "inventory" and hide him and in the game
			AIInventory.Add(other.gameObject);
			other.gameObject.SetActive(false);
		}
	}

	public int GetNumberOfPeople()
	{
		return AIInventory.Count;
	}
}