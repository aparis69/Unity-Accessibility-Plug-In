using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseAnalyser : MonoBehaviour
{
    // Mouse Position analysing
    // Data retreived from calibration, can use only the first index or the whole List<>
    private List<UserData> userDataCalibration;

    // Data retreived from the player during the game
    private List<Vector2> mPositionPlayer;

    // Other variables
    private bool canAnalyse;
	private int previousVectorsToCompare = 10;
	private float magnitudeThreshold = 3.0f;
	private float directionAngleChangeThreshold = 45.0f;

	void Start () 
    {
        mPositionPlayer = new List<Vector2>();
        userDataCalibration = CalibrationDataRead.GetMousePositionData();
        canAnalyse = false;
	}
	
	void Update () 
    {
	    if(canAnalyse)
        {
            CompareData();
            canAnalyse = false;
        }
	}

    private void CompareData()
    {
		int c1 = countQuickMouseDirectionChanges(userDataCalibration[0].GetMousePositions());
		int c2 = countQuickMouseDirectionChanges(mPositionPlayer);

		if (c2 > c1 * 5) 
		{
			Debug.Log("Player had trouble using the mouse correctly. Unusual jittering in the mouse inputs was detected.");
		}
    }

	public int countQuickMouseDirectionChanges(List<Vector2> mousePositions) 
	{
		Vector2[] mVectorSnippet;
		Vector2 currentVector;
		int directionChangeCount = 0;
		int currentCount = 0;

		while (currentCount + previousVectorsToCompare < mousePositions.Count)
		{
			//Store a snippet of mouse directions
			mVectorSnippet = new Vector2[previousVectorsToCompare];
			for (int i = 0; i < previousVectorsToCompare; i++)
			{
				currentVector = mousePositions[currentCount + i + 1] - mousePositions[currentCount + i];
				if (currentVector.magnitude > magnitudeThreshold)
					mVectorSnippet[i] = currentVector;
				else
					mVectorSnippet[i] = Vector2.zero;
			}

			//Count quick direction changes in the snippet
			for (int j = mVectorSnippet.Length - 1; j >= 0; j--)
			{
				currentVector = mVectorSnippet[j];
				if (currentVector == Vector2.zero)
					continue;

				for (int k = j - 1; k >= 0; k--)
				{
					if (mousePositions[j] != Vector2.zero && currentVector != Vector2.zero
					&& Vector2.Angle(mousePositions[j], currentVector) < directionAngleChangeThreshold)
					{
						directionChangeCount++;
						j = k;
						break;
					}
				}
			}

			currentCount += previousVectorsToCompare;
		}

		return directionChangeCount;
	}

    public void SetMousePositionFromPlayer(List<Vector2> mPlayer)
    {
        mPositionPlayer = mPlayer;
    }

    public void CanAnalyse(bool can)
    {
        canAnalyse = can;
    }

}
