using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class OnEnteringSafeZone : MonoBehaviour 
{
	void Start ()
    {
        PlayerPrefs.SetInt("Game off", 0);
	}
	
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Game off", 1);
            other.gameObject.GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
