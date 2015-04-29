using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseAnalyser 
{
	private static int previousVectorsToCompare = 10;
	private static float magnitudeThreshold = 3.0f;
	private static float directionAngleChangeThreshold = 45.0f;

	public static void CompareData(UserData calibrateData, UserData playerData)
	{
		int c1 = CountQuickMouseDirectionChanges(calibrateData.GetMouseInput().getMousePointerPosition());
		int c2 = CountQuickMouseDirectionChanges(playerData.GetMouseInput().getMousePointerPosition());

		if (c2 > c1 * 5)
			Debug.Log("Player had trouble using the mouse correctly. Unusual jittering in the mouse inputs was detected.");
	}

	private static int CountQuickMouseDirectionChanges(List<Vector2> mousePositions)
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
}
