using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceAccess : MonoBehaviour 
{
	public AudioSource source;
	private SubtitleManagement subManager;

	void Start ()
	{
		source = this.GetComponent<AudioSource>();
		subManager = FindObjectOfType<SubtitleManagement>();
	}

	// Interaction function
	public void Play()
	{
		source.Play();
		if (subManager.IsShowingSubtitle() == true) 
		{
			subManager.AddSubtitle(source);
		}
	}

	public void PlayAmbient()
	{
		source.Play();
		//if (subManager.IsShowingSubtitle() == true)
		//{
		//	subManager.AddAmbientSubtitle(source);
		//}
	}

	public void PlayOneShot(AudioClip clip)
	{
		source.PlayOneShot(clip);
		if (subManager.IsShowingSubtitle() == true)
		{
			subManager.AddSubtitle(source);
		}
	}

	public void Stop()
	{
		source.Stop();
		if (subManager.IsShowingSubtitle() == true)
		{

		}
	}

	public bool IsPlaying()
	{
		return source.isPlaying;
	}
}