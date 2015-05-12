using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	private int score;

	void Start () 
	{
		
	}

	void Update () 
	{
	}

	public int GetScore()
	{
		return score;
	}

	public void SetScore(int s)
	{
		score = s;
	}
}