using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalibrationDataRead
{
    public static List<KeyInput> GetKeyboardData()
    {
        // Read the calibration files and store all the data into a List<UserData>, and return the List<KeyInput> that contains the average value for each keyboard input
        int numberOfFile = 0;
        do
        {
            if (System.IO.File.Exists("./Data/Calibration/Keyboard Inputs/Keyboard" + numberOfFile.ToString() + ".txt"))
                numberOfFile++;
            else
                break;
        } while (true);

        // Read the data
        List<UserData> usersData = new List<UserData>();
        for (int i = 0; i < numberOfFile; i++)
        {
            List<KeyInput> keys = new List<KeyInput>();
            string[] lines = System.IO.File.ReadAllLines("./Data/Calibration/Keyboard Inputs/Keyboard" + i.ToString() + ".txt");

            foreach(string line in lines)
            {
                string[] words = line.Split(',');
                KeyInput k = new KeyInput((KeyCode)System.Enum.Parse(typeof(KeyCode), words[0]));
                int hit = 0;
                int.TryParse(words[1], out hit);
                int doubleStrike = 0;
                int.TryParse(words[2], out doubleStrike);
               
                // Store the values
                k.SetHit(hit);
                k.SetDoubleStrikingCount(doubleStrike);

                keys.Add(k);
            }
            usersData.Add(new UserData(keys));
        }

        // Return the average value from the user data
        return GetAverageKeyInputValues(usersData);
    }

    private static List<KeyInput> GetAverageKeyInputValues(List<UserData> usersData)
    {
        List<KeyInput> averageKeyInputValue = new List<KeyInput>();

        for (int i = 0; i < usersData.Count; i++ )
        {
            foreach(KeyInput key in usersData[i].GetKeyInput())
            {
                bool isinlist = false;

                foreach (KeyInput k in averageKeyInputValue)
                {
                    // If keycode already exist in the list, we sum the hit counts and occurences count
                    if(key.GetKeyCode() == k.GetKeyCode())
                    {
                        k.SetOccurences(k.GetOccurences() + 1);
                        k.SetHit(k.GetHitCount() + key.GetHitCount());
                        k.SetDoubleStrikingCount(k.GetDoubleStrikingCount() + key.GetDoubleStrikingCount());
                        isinlist = true;
                    }
                }
                // if keycode does not exist, we add it to the list
                if(!isinlist)
                {
                    key.SetOccurences(1);
                    averageKeyInputValue.Add(key);
                }
            }
        }

        foreach (KeyInput k in averageKeyInputValue)
        {
            k.SetHit(k.GetHitCount() / k.GetOccurences());
            k.SetDoubleStrikingCount(k.GetDoubleStrikingCount() / k.GetOccurences());
        }

        return averageKeyInputValue;
    }

    public static List<UserData> GetMousePositionData()
    {
        // Read the calibration files and store all the data into a List<UserData>, and return the List<KeyInput> that contains the average value for each keyboard input
        int numberOfFile = 0;
        do
        {
			if (System.IO.File.Exists("./Data/Calibration/Mouse Positions/MousePositions" + numberOfFile.ToString() + ".txt"))
                numberOfFile++;
            else
                break;
        } while (true);


        // Read the data
        List<UserData> usersData = new List<UserData>();
        for (int i = 0; i < numberOfFile; i++)
        {
            UserData user = new UserData();
            string[] lines = System.IO.File.ReadAllLines("./Data/Calibration/Mouse Positions/MousePositions" + i.ToString() + ".txt");

            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                float x, y;
                float.TryParse(words[0], out x);
                float.TryParse(words[1], out y);

                Vector2 vec = new Vector2(x, y);

                user.AddMousePosition(vec);
            }

            usersData.Add(user);
        }

        // Return the average value from the user data
        return usersData;
    }
}