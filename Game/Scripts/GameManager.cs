using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public AIManager aiManager;
	public GameObject player;
	private GameObject[] fireObjects;

	void Start () 
	{
		fireObjects = GameObject.FindGameObjectsWithTag("Fire");
		for (int i = 0; i < fireObjects.Length; i++)
			fireObjects[i].SetActive(false);
	}

	void Update() 
	{
		// Check the player lifepoint
		if (player.GetComponent<PlayerLifePoint>().GetLifePoint() <= 0)
		{
			// Respawn the player to the starting point with 100 points
			player.GetComponent<PlayerLifePoint>().ResetLifePoint();
			player.GetComponent<PlayerLifePoint>().RespawnToStartingPoint();
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			// Activate fire
			for (int i = 0; i < fireObjects.Length; i++)
				fireObjects[i].SetActive(true);

			// Activate AI and scared AI
			aiManager.ManageAI();
		}
	}
}
