using UnityEngine;
using System.Collections;

public class PluginSoundManager : MonoBehaviour 
{
	public Transform cameraTransform;

	public UnityEngine.UI.Text subtitleArea;
	public GameObject[] UIObjects;

	public AudioSource[] audioSources;
	public bool canShowInterface;

	void Start () 
	{
		// Get all the audio source in the scene
		audioSources = (AudioSource[])GameObject.FindObjectsOfType(typeof(AudioSource));

		// hide the sound manager interface
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(false);

		canShowInterface = false;

	}


	void Update () 
	{
		if (canShowInterface == true) 
		{
			subtitleArea.text = "";
			for (int i = 0; i < audioSources.Length; i++)
			{
				if (audioSources[i].enabled == true && audioSources[i].isPlaying == true)
				{
					subtitleArea.text = audioSources[i].clip.name + " sound, " + GetSoundDirection(Vector3.zero) + ", " + GetSoundDistance(Vector3.zero);
				}
			}
		}
			
	}


	public string GetSoundDirection(Vector3 soundPosition) 
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

	public string GetSoundDistance(Vector3 soundPosition)
	{
		int distance = Mathf.RoundToInt(Vector3.Distance(cameraTransform.position, soundPosition));
		return distance.ToString() + " meters away";
	}



	public void SwitchDisplay() 
	{
		if (canShowInterface == true)
			HideInterface();
		else
			ShowInterface();
	}


	public void ShowInterface()
	{
		for (int i = 0; i < UIObjects.Length; i++)
			UIObjects[i].SetActive(true);

		canShowInterface = true;
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