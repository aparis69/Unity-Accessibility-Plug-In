using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEvents : MonoBehaviour 
{
	public Text lifePoint;
	public GameObject player;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		// Update life player on the UI
		lifePoint.text = player.GetComponent<PlayerLifePoint>().GetLifePoint().ToString();
	}
}
