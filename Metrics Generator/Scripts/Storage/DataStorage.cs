using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataStorage
{
    public static void StoreKeyboardInput(List<KeyInput> keysInput, bool calibrationMode)
    {
        List<string> keyboardInputStrings = new List<string>();
        foreach (KeyInput KC in keysInput)
            keyboardInputStrings.Add(KC.GetKeyCode().ToString() + "," + KC.GetHitCount().ToString() + "," + KC.GetDoubleStrikingCount().ToString());

        // Determine a new name for the future file
        int i = 0;
        do
        {
            if (!System.IO.File.Exists(@"H:\Game Analytics\Data\Calibration\Keyboard Inputs\Keyboard" + i.ToString() + ".txt"))
                break;
            i++;
        } while (true);

        // Create the file
        if(calibrationMode)
            System.IO.File.WriteAllLines(@"H:\Game Analytics\Data\Calibration\Keyboard Inputs\Keyboard" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
        else
            System.IO.File.WriteAllLines(@"H:\Game Analytics\Data\Analysis\Keyboard Inputs\Keyboard" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
    }

    public static void StoreMousePositionFromArray(float[][] mousePositionArray, bool calibrationMode)
    {
        float? maxVal = null; // nullable so this works even if you have all super-low negatives
        for (int i = 0; i < mousePositionArray.Length; i++)
        {
            for (int j = 0; j < mousePositionArray[i].Length; j++)
            {
                float thisNum = mousePositionArray[i][j];
                if (!maxVal.HasValue || thisNum > maxVal.Value)
                {
                    maxVal = thisNum;
                }
            }
        }

        // Create the texture
        Texture2D tex = new Texture2D(Screen.width, Screen.height);
        for (int i = 0 ; i < Screen.width ; i++)
            for (int j = 0; j < Screen.height; j++)
            {
                if (mousePositionArray[i][j] == 0f)
                    tex.SetPixel(i, j, new Color(1f, 1f, 1f));
                else
                    tex.SetPixel(i, j, new Color(1f - mousePositionArray[i][j] / maxVal.Value, 0f, 0f));
            }

        byte[] bytes = tex.EncodeToPNG();

        // Determine a new name for the future file
        int a = 0;
        do
        {
            if (!System.IO.File.Exists(@"H:\Game Analytics\Data\Mouse Positions\MousePositions" + a.ToString() + ".png"))
                break;
            a++;
        } while (true);

        // Saving the data as a png file
        //System.IO.File.WriteAllBytes(@"H:\Game Analytics\Data\Mouse Positions\MousePositions" + a.ToString() + ".png", bytes);
    }

    public static void StoreMousePositionFromList()
    {

    }

    public static void StoreMouseMovements(List<float> mouseMovements, bool calibrationMode)
    {
        // Format the content
        List<string> keyboardInputStrings = new List<string>();
        int i = 0;
        foreach (float value in mouseMovements)
        {
            keyboardInputStrings.Add(i.ToString() + "," + value.ToString());
            i++;
        }


        // Determine a new name for the future file
        i = 0;
        do
        {
            if (!System.IO.File.Exists(@"H:\Game Analytics\Data\Mouse Movements\MouseMovements" + i.ToString() + ".txt"))
                break;
            i++;
        } while (true);


        // Create the file
        //System.IO.File.WriteAllLines(@"H:\Game Analytics\Data\Mouse Movements\MouseMovements" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
    }
}