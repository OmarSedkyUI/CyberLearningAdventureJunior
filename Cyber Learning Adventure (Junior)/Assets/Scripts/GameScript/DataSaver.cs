using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static int ReadLevelCurrentIndexValues(string name)
    {
        var value = -1;
        if (PlayerPrefs.HasKey(name))
            value = PlayerPrefs.GetInt(name);

        return value;
    }

    public static void SaveLevelData(string levelName, int currentIndex)
    {
        PlayerPrefs.SetInt(levelName, currentIndex);
        PlayerPrefs.Save();
    }

    public static void ClearGameData(GameLevelData levelData)
    {
        foreach (var data in levelData.data)
        {
            PlayerPrefs.SetInt(data.levelName, -1);
        }

        PlayerPrefs.SetInt(levelData.data[0].levelName, 0);
        PlayerPrefs.Save();
    }
}
