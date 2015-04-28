using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalibrationDataStorage
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
			if (calibrationMode && !System.IO.File.Exists("./Data/Calibration/Keyboard Inputs/Keyboard" + i.ToString() + ".txt"))
                break;
			if (!calibrationMode && !System.IO.File.Exists("./Data/Analysis/Keyboard Inputs/Keyboard" + i.ToString() + ".txt"))
				break;
            i++;
        } while (true);

        // Create the file
        if(calibrationMode)
            System.IO.File.WriteAllLines("./Data/Calibration/Keyboard Inputs/Keyboard" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
        else
            System.IO.File.WriteAllLines("./Data/Analysis/Keyboard Inputs/Keyboard" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
    }

    public static void StoreMousePositionFromList(List<Vector2> mousePositions, bool calibrationMode)
    {
        List<string> mousePositionsStrings = new List<string>();
        foreach (Vector2 vec in mousePositions)
            mousePositionsStrings.Add(vec.x + "," + vec.y);

        // Determine a new name for the future file
        int i = 0;
        do
        {
            if (calibrationMode && !System.IO.File.Exists("./Data/Calibration/Mouse Positions/MousePositions" + i.ToString() + ".txt"))
                break;
			if (!calibrationMode && !System.IO.File.Exists("./Data/Analysis/Mouse Positions/MousePositions" + i.ToString() + ".txt"))
				break;
            i++;
        } while (true);


        // Create the file
        if (calibrationMode)
			System.IO.File.WriteAllLines("./Data/Calibration/Mouse Positions/MousePositions" + i.ToString() + ".txt", mousePositionsStrings.ToArray());
        else
			System.IO.File.WriteAllLines("./Data/Analysis/Mouse Positions/MousePositions" + i.ToString() + ".txt", mousePositionsStrings.ToArray());
    }

    public static void StoreMouseClicks(List<int> mouseButtonClicks, List<int> mouseClickCount, bool calibrationMode)
    {

        List<string> mouseClicksStrings = new List<string>();
        foreach (int Click in mouseButtonClicks)
        {
            if (Click == 0)
                mouseClicksStrings.Add(Click.ToString() + " //Left Click");
            if (Click == 1)
                mouseClicksStrings.Add(Click.ToString() + " //Right Click");
            if (Click == 2)
                mouseClicksStrings.Add(Click.ToString() + " //Middle Click");
        }

        mouseClicksStrings.Add("Left clicks : " + mouseClickCount[0]);
        mouseClicksStrings.Add("Right clicks : " + mouseClickCount[1]);
        mouseClicksStrings.Add("Middle clicks : " + mouseClickCount[2]);
        

        // Determine a new name for the future file
        int i = 0;
        do
        {
            if (calibrationMode && !System.IO.File.Exists("./Data/Calibration/Mouse Clicks/MouseClicks" + i.ToString() + ".txt"))
                break;
            if (!calibrationMode && !System.IO.File.Exists("./Data/Analysis/Mouse Clicks/MouseClicks" + i.ToString() + ".txt"))
                break;
            i++;
        } while (true);

        // Create the file
        if (calibrationMode)
            System.IO.File.WriteAllLines("./Data/Calibration/Mouse Clicks/MouseClicks" + i.ToString() + ".txt", mouseClicksStrings.ToArray());
        else
            System.IO.File.WriteAllLines("./Data/Analysis/Mouse Clicks/MouseClicks" + i.ToString() + ".txt", mouseClicksStrings.ToArray());
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
            if (!System.IO.File.Exists(@"H:/Game Analytics/Data/Mouse Movements/MouseMovements" + i.ToString() + ".txt"))
                break;
            i++;
        } while (true);


        // Create the file
        //System.IO.File.WriteAllLines(@"H:/Game Analytics/Data/Mouse Movements/MouseMovements" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
    }
}