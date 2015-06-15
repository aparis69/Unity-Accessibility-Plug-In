using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public AudioSource[] audioSources;
	public SoundItem[] soundItems;
	public GameObject soundItemPrefab;
	public GameObject soundManagerButton;
	private bool showingSoundList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void GetAudioSources() 
	{
		audioSources = FindObjectsOfType<AudioSource>();

		List<string> audioSourcesName = new List<string>();
		List<List<AudioSource>> clipsList = new List<List<AudioSource>>();
		for (int i = 0; i < audioSources.Length; i++)
		{
			if (audioSources[i].clip == null)
				continue;

			if (audioSourcesName.Contains(audioSources[i].clip.name))
			{
				clipsList[audioSourcesName.IndexOf(audioSources[i].clip.name)].Add(audioSources[i]);
			}
			else 
			{
				clipsList.Add(new List<AudioSource>());
				clipsList[clipsList.Count - 1].Add(audioSources[i]);
				audioSourcesName.Add(audioSources[i].clip.name);
			}
		}


		float offset = 0.0f;
		soundItems = new SoundItem[clipsList.Count];
		for (int i = 0; i < clipsList.Count; i++) 
		{
			offset -= 40.0f;

			GameObject obj = (GameObject)GameObject.Instantiate(soundItemPrefab);
			obj.transform.SetParent(this.soundManagerButton.transform);

			RectTransform rect = obj.GetComponent<RectTransform>();
			Vector2 vect = new Vector2(0.0f, offset);
			rect.anchoredPosition = vect;
			
			SoundItem soundItem = obj.GetComponent<SoundItem>();
			soundItem.audioSources = clipsList[i].ToArray();
			soundItem.initDisplay();
			soundItems[i] = soundItem;
		}
	}



	public void SwitchDisplay()
	{
		if (showingSoundList)
		{
			HideInterface();
		}
		else 
		{
			ShowInterface();
		}	
	}


	private void ShowInterface()
	{
		GetAudioSources();
		showingSoundList = true;
	}

	private void HideInterface()
	{
		for (int i = 0; i < soundItems.Length; i++)
			Destroy(soundItems[i].gameObject);
		audioSources = null;
		soundItems = null;
		showingSoundList = false;
	}
}