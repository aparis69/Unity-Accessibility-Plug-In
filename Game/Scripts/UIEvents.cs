using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEvents : MonoBehaviour 
{
	public Text lifePoint;
	public Text typingText;
	public GameObject player;

	void Start () 
	{
		typingText.text = "Please type this sentence : My name is Robert and I am currently working as a employee in X office";
	}
	
	void Update () 
	{
		// Update life player on the UI
		lifePoint.text = player.GetComponent<PlayerLifePoint>().GetLifePoint().ToString();
	}
}