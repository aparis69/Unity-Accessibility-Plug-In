using UnityEngine;
using System.Collections;

public class KeyInput 
{
    // Used in the tracking part
    private KeyCode key;
    private int hitCount;
    private int doubleStrikingCount;

    // Used to measure double strike hit
    private float timeSinceLastHit;

    // Only used in the analysis part
    private int occurences;

    public KeyInput(KeyCode code)
    {
        this.key = code;
        
        timeSinceLastHit = -1f;
        hitCount = 0;
        doubleStrikingCount = 0;

        occurences = 0;
    }

    public void IncreaseHit(float time)
    {
        if (time - timeSinceLastHit < 0.3f)
            doubleStrikingCount++;

        timeSinceLastHit = time;
        hitCount++;
    }

    public void SetHit(int h)
    {
        hitCount = h;
    }

    public void SetDoubleStrikingCount(int db)
    {
        doubleStrikingCount = db;
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
        return doubleStrikingCount;
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