using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseAnalyser 
{
	// Variables to personalize the jittering calculation algorithm
	private static int previousVectorsToCompare = 10;
	private static float magnitudeThreshold = 1.0f;
	private static float directionAngleChangeThreshold = 90.0f;

	public static void CompareData(UserData calibrateData, UserData playerData)
	{
		int c2 = CountQuickMouseDirectionChanges(playerData.GetMouseInput().getMousePointerPosition());

		if (c2 > calibrateData.GetMouseInput().GetJitteringCount() * 5 && InputAccess.MouseSensivityOptionEnabled() == false)
		{
			Debug.Log("Player had trouble using the mouse correctly. Unusual jittering in the mouse inputs was detected.");
		}
	}

	public static int CountQuickMouseDirectionChanges(List<Vector2> mousePositions)
	{
		Vector2[] mouseVectorSnippet;
		Vector2 currentVector;
		int directionChangeCount = 0;
		int currentCount = 0;

		while (currentCount + previousVectorsToCompare < mousePositions.Count)
		{
			//Store a snippet of mouse directions
			mouseVectorSnippet = new Vector2[previousVectorsToCompare];
			for (int i = 0; i < previousVectorsToCompare; i++)
			{
				currentVector = mousePositions[currentCount + i + 1] - mousePositions[currentCount + i];
				if (currentVector.magnitude > magnitudeThreshold)
					mouseVectorSnippet[i] = currentVector;
				else
					mouseVectorSnippet[i] = Vector2.zero;

			}

			//Count quick direction changes in the snippet
			for (int j = mouseVectorSnippet.Length - 1; j >= 0; j--)
			{
				currentVector = mouseVectorSnippet[j];
				if (currentVector == Vector2.zero)
					continue;

				for (int k = j - 1; k >= 0; k--)
				{
					if (mouseVectorSnippet[k] != Vector2.zero && currentVector != Vector2.zero
					&& Vector2.Angle(mouseVectorSnippet[k], currentVector) > directionAngleChangeThreshold)
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
