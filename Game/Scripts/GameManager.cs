using UnityEngine;
using System.Collections;

/// <summary>
/// Game Manager, triggers the events of the beginning of the game like the calm phase, and then the alarm sound and fire...
/// </summary>
public class GameManager : MonoBehaviour
{
	public AIManager aiManager;
	public GameObject player;
	public GameObject[] typingUIObjects;
	public float calmPhaseDuration;
	public AudioClip officeSounds;
	public AudioClip alarmSound;

	private GameObject[] fireObjects;
	private bool gameIsOn;
	private bool firstPass;
	private float timerCalmPhase;

	void Start()
	{
		fireObjects = GameObject.FindGameObjectsWithTag("Fire");
		for (int i = 0; i < fireObjects.Length; i++)
			fireObjects[i].SetActive(false);

		// At first, the player will have to type some words on his keyboard
		gameIsOn = false;
		firstPass = false;
		timerCalmPhase = Time.realtimeSinceStartup + calmPhaseDuration;

		for (int i = 0; i < typingUIObjects.Length; i++)
			typingUIObjects[i].SetActive(true);

		this.GetComponent<AudioSource>().clip = officeSounds;
		this.GetComponent<AudioSourceAccess>().PlayAmbient();
	}

	void Update()
	{
		// Calm phase
		if (!gameIsOn)
		{
			// Activate the game at the end of the calm phase timer
			if (Time.realtimeSinceStartup - timerCalmPhase > 0f)
			{
				gameIsOn = true;
				firstPass = true;
				this.GetComponent<AudioSource>().clip = alarmSound;
				this.GetComponent<AudioSourceAccess>().PlayAmbient();
				for (int i = 0; i < typingUIObjects.Length; i++)
					typingUIObjects[i].SetActive(false);
			}
		}
		// Game phase
		else
		{
			// First pass, trigger the game events
			if (firstPass)
			{
				// Activate fire
				for (int i = 0; i < fireObjects.Length; i++)
					fireObjects[i].SetActive(true);
				// Activate AI and scared AI
				aiManager.ManageAI();
				// Activate the player controller script
				player.GetComponent<FirstPersonController>().ActivateGame();

				firstPass = false;
			}

			// Check the player lifepoint during all game phase
			if (player.GetComponent<PlayerLifePoint>().GetLifePoint() <= 0)
			{
				// Respawn the player to the starting point with 1000 points
				player.GetComponent<PlayerLifePoint>().ResetLifePoint();
				player.GetComponent<PlayerLifePoint>().RespawnToStartingPoint();
			}
		}
	}
}