using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataStorage
{
    public static void StoreKeyboardInput(List<KeyCode> KCList, List<int> KCNum)
    {
        // Format the content
        List<string> keyboardInputStrings = new List<string>();
        foreach(KeyCode KC in KCList)
            keyboardInputStrings.Add(KC.ToString() + "," + KCNum[KCList.IndexOf(KC)]);

        
        // Determine a new name for the future file
        int i = 0;
        do
        {
            if (!System.IO.File.Exists(@"H:\Game Analytics\Data\Keyboard Inputs\Keyboard" + i.ToString() + ".txt"))
                break;
            i++;
        } while (true);


        // Create the file
        System.IO.File.WriteAllLines(@"H:\Game Analytics\Data\Keyboard Inputs\Keyboard" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
    }

    public static void StoreMousePosition(int[][] mousePositionArray)
    {

    }

    public static void StoreMouseMovements(List<float> mouseMovements)
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
        System.IO.File.WriteAllLines(@"H:\Game Analytics\Data\Mouse Movements\MouseMovements" + i.ToString() + ".txt", keyboardInputStrings.ToArray());
    }
}
