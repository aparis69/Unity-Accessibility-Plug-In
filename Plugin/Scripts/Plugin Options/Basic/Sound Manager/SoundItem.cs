using UnityEngine;
using System.Collections;

public class SoundItem : MonoBehaviour
{
	public AudioSource[] audioSources;
	private UnityEngine.UI.Text label;
	private UnityEngine.UI.Slider slider;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void initDisplay() 
	{
		label = this.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
		slider = this.GetComponent<UnityEngine.UI.Slider>();

		
		label.text = audioSources[0].clip.name + " sounds";

		slider.value = 1.0f;
	}

	public void volumeSliderChange()
	{
		for (int i = 0; i < audioSources.Length; i++)
			audioSources[i].volume = slider.value;
	}
	
}
