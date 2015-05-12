using UnityEngine;
using System.Collections;

public class PlayerLifePoint : MonoBehaviour
{
	private Vector3 startingPosition;
	private int numberOfPoint = 1000;
	private int initialNumberOfPoint;
	private int numberOfLoose = 0;

	void Start()
	{
		startingPosition = this.transform.position;
		initialNumberOfPoint = numberOfPoint;
	}

	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		// If the player has a contact with a fire, he looses lifepoint
		if (other.gameObject.CompareTag("Fire"))
			numberOfPoint -= 2;
	}

	void OnTriggerStay(Collider other)
	{
		// If the player has a contact with a fire, he looses lifepoint
		if (other.gameObject.CompareTag("Fire"))
			numberOfPoint -= 1;
	}

	public int GetLifePoint()
	{
		return numberOfPoint;
	}

	public void ResetLifePoint()
	{
		numberOfPoint = initialNumberOfPoint;
	}

	public void RespawnToStartingPoint()
	{
		this.transform.position = startingPosition;
		numberOfLoose++;
	}

	public int GetNumberOfLoose()
	{
		return numberOfLoose;
	}
}