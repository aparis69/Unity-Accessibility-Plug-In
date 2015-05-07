using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	private int currentScore;
	public int score;

	void Start () 
	{
		currentScore = 0;
	}

	void Update () 
	{
		currentScore++;

		if (currentScore == 10)
			currentScore = 0;
	}

	public int GetScore()
	{
		return score;
	}
}