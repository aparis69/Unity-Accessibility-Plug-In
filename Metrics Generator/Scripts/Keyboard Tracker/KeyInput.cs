using UnityEngine;
using System.Collections;

public class KeyInput 
{
    // Used in the tracking part
    private KeyCode key;
    private int hitCount;
    private int doubleStrikeCount;

    // Used to measure double strike hit
    private float timeSinceLastHit;

    // Only used in the analysis part
    private int occurences;

    public KeyInput(KeyCode code)
    {
        this.key = code;
        
        timeSinceLastHit = -1f;
        hitCount = 0;
        doubleStrikeCount = 0;

        occurences = 0;
    }

    public KeyInput(KeyCode code, int hitCount, int doubleStrikeCount)
    {
        this.key = code;

        this.timeSinceLastHit = -1f;
        this.hitCount = hitCount;
        this.doubleStrikeCount = doubleStrikeCount;

        this.occurences = 0;
    }

    public void IncreaseHit(float time)
    {
        if (time - timeSinceLastHit < 0.3f)
            doubleStrikeCount++;

        timeSinceLastHit = time;
        hitCount++;
    }

    public void SetHit(int h)
    {
        hitCount = h;
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

    public void SetOccurences(int o)
    {
        occurences = o;
    }

    public int GetOccurences()
    {
        return occurences;
    }
}