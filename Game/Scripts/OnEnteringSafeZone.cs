using UnityEngine;
using System.Collections;

public class OnEnteringSafeZone : MonoBehaviour 
{
	private ScoreManager scoreManager;
	public GameObject gameManagerObject;

	void Start ()
    {
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        PlayerPrefs.SetInt("Game off", 0);
	}
	
	void Update () 
    {
	
	}

	// If a gameobject enter the safe zone
    void OnTriggerEnter(Collider other)
    {
		// if player : end of the game
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Game off", 1);
			gameManagerObject.SetActive(false);
			gameManagerObject.GetComponent<AudioSource>().Stop();
			scoreManager.SetScore(other.gameObject.GetComponentInChildren<GrabPeople>().GetNumberOfPeople());
            other.gameObject.GetComponent<FirstPersonController>().enabled = false;
        }
		// if AI : destroy it
		if (other.gameObject.CompareTag("AI"))
		{
			other.gameObject.SetActive(false);
		}
    }
}