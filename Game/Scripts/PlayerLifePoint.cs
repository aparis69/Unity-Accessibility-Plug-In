using UnityEngine;
using System.Collections;

public class PlayerLifePoint : MonoBehaviour
{
	private int numberOfPoint = 100;

	void Start()
	{

	}

	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.tag);
		// If the player has a contact with a fire, he looses lifepoint
		if (other.gameObject.CompareTag("Fire"))
			numberOfPoint -= 1;
	}

	public int GetLifePoint()
	{
		return numberOfPoint;
	}
}