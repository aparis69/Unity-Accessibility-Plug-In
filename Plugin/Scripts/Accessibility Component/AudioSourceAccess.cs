using UnityEngine;
using System.Collections;

public class AudioSourceAccess : MonoBehaviour 
{
	public AudioClip clip;
	private AudioSource source;

	// State variable
	private bool isPlaying;

	void Start ()
	{
		source = new AudioSource();
		source.clip = clip;
		isPlaying = false;
	}


	// Interaction function
	public void Play()
	{
		source.Play();
		isPlaying = true;
	}

	public void Stop()
	{
		source.Stop();
		isPlaying = false;
	}

	public bool IsPlaying()
	{
		return isPlaying;
	}
}