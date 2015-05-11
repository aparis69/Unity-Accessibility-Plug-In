using UnityEngine;
using System.Collections;

public class PluginSoundManager : MonoBehaviour 
{
	public GameObject[] UIObjects;

	private AudioSource[] audioSources;
	private bool canShowInterface;

	void Start () 
	{
		// Get all the audio source in the scene
		audioSources = (AudioSource[])GameObject.FindObjectsOfType(typeof(AudioSource));
		// hide the sound manager interface
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(false);
	}

	public void ShowInterface()
	{
		canShowInterface = true;
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(true);
	}

	private void InitializeComponent()
	{

	}

	public void HideInterface()
	{
		canShowInterface = false;
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(false);
	}
}