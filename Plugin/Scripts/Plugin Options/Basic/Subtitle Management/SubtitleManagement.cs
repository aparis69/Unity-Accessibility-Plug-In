using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SubtitleManagement : MonoBehaviour 
{
	public Text subtitleArea;
	public GameObject[] UIObjects;

	private Transform cameraTransform;
	private bool showingSubtitle;

	private List<string> subList = new List<string>();
	private List<string> ambientSubList = new List<string>();
	private float timer;
	public float subtitleLifeSpan = 1.0f;

	void Start () 
	{
		// Get the main camera in the scene
		cameraTransform = Camera.main.transform;

		// hide the sound manager interface
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(false);

		showingSubtitle = false;

		timer = subtitleLifeSpan;
	}

	void Update () 
	{
		if (timer > 0.0f)
		{
			timer -= Time.deltaTime;
		}
		else 
		{
			if (subList.Count > 0) 
			{
				subList.RemoveAt(0);
				UpdateText();
				timer = subtitleLifeSpan;
			}			
		}
	}

	public void AddSubtitle(AudioSource source) 
	{
		if (Vector3.Distance(cameraTransform.position, source.transform.position) < 1.5f)
		{
			subList.Add(source.clip.name + " sound, right on you" + "\n");
		}
		else 
		{
			subList.Add(source.clip.name + " sound, " + GetSoundDirection(source.transform.position) + ", " + GetSoundDistance(source.transform.position) + "\n");
		}
		
		if (subList.Count > 2) 
		{
			subList.RemoveAt(0);
		}
		
		UpdateText();
		
		if (timer <= 0.0f) 
		{
			timer = subtitleLifeSpan;
		}
	}

	public void AddAmbientSubtitle(AudioSource source)
	{
		ambientSubList.Add("(Ambient) " + source.clip.name + " sound" + "\n");

		UpdateText();

		if (timer <= 0.0f)
		{
			timer = subtitleLifeSpan;
		}
	}

	public void UpdateText() 
	{
		subtitleArea.text = "";

		if (subList.Count == 0)
		{
			for (int i = 0; i < ambientSubList.Count; i++)
			{
				subtitleArea.text += ambientSubList[i];
			}
		}
		else 
		{
			for (int i = 0; i < subList.Count; i++)
			{
				subtitleArea.text += subList[i];
			}
		}
		
	}


	public void SwitchDisplay()
	{
		if (showingSubtitle)
			HideInterface();
		else
			ShowInterface();
	}

	private string GetSoundDirection(Vector3 soundPosition) 
	{
		Vector3 camToSound = soundPosition - cameraTransform.position;

		float flatAngle = Vector2.Angle(new Vector2(cameraTransform.forward.x, cameraTransform.forward.z), new Vector2(camToSound.x, camToSound.z));

		if (Vector3.Angle(cameraTransform.right, soundPosition - cameraTransform.position) > 90f) // on the left
			flatAngle = 360 - flatAngle;

		if (flatAngle >= 315 || flatAngle < 45) //from forward
			return "in front of you";
		else if (flatAngle >= 45 && flatAngle < 135) //from the right
			return "on your right";
		else if (flatAngle >= 135 && flatAngle < 225) //from behind
			return "behind you";
		else if (flatAngle >= 225 && flatAngle < 315) //from the left
			return "on your left";

		return "";
	}

	private string GetSoundDistance(Vector3 soundPosition)
	{
		int distance = Mathf.RoundToInt(Vector3.Distance(cameraTransform.position, soundPosition));
		return distance.ToString() + " meters away";
	}

	private void ShowInterface()
	{
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(true);

		showingSubtitle = true;
	}

	private void HideInterface()
	{
		showingSubtitle = false;
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(false);
	}

	public bool IsShowingSubtitle() 
	{
		return showingSubtitle;
	}

}