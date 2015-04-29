using UnityEngine;
using System.Collections;

public class KeyInput
{
	private KeyCode key;
	private int hitCount;
	private int doubleStrikeCount;

	private float timeSinceLastHit;

	public KeyInput(KeyCode code)
	{
		this.key = code;
		hitCount = 0;
		doubleStrikeCount = 0;
		timeSinceLastHit = -1f;
	}

	public KeyInput(KeyCode code, int hitCount, int doubleStrikeCount)
	{
		this.key = code;
		this.hitCount = hitCount;
		this.doubleStrikeCount = doubleStrikeCount;
		this.timeSinceLastHit = -1f;
	}

	public void IncreaseHitCount(float time)
	{
		if (time - timeSinceLastHit < 0.3f)
			doubleStrikeCount++;

		timeSinceLastHit = time;
		hitCount++;
	}

	public void SetHitCount(int count)
	{
		hitCount = count;
	}

	public void SetDoubleStrikingCount(int db)
	{
		doubleStrikeCount = db;
	}

	public KeyCode GetKeyCode()
	{
		return key;
	}

	public int GetHitCount()
	{
		return hitCount;
	}

	public int GetDoubleStrikingCount()
	{
		return doubleStrikeCount;
	}
}