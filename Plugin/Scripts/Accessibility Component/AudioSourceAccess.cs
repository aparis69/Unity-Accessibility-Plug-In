using UnityEngine;
using System.Collections;

/// <summary>
/// Override of the Unity AudioSource component, allows the player to use subtitles and sound management
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioSourceAccess : MonoBehaviour 
{
	public AudioSource source;
	private SubtitleManagement subManager;

	void Awake ()
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
			subManager.AddAmbientSubtitle(source);
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