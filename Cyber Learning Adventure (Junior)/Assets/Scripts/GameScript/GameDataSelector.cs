using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataSelector : MonoBehaviour
{
    public GameData currentGameData;
    public GameLevelData levelData;

    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "GameScene")
        {
            SelectNextLevel();
        }
    }

    public void Button()
    {
        SelectNextLevel();
    }

    private void SelectNextLevel()
    {
        foreach (var data in levelData.data)
        {
            if (data.levelName == currentGameData.selectedLevelName)
            {
                var levelIndex = DataSaver.ReadLevelCurrentIndexValues(currentGameData.selectedLevelName);

                if(levelIndex < data.levelData.Count)
                {
                    currentGameData.selectedLevelName = data.levelData[levelIndex];
                    currentGameData.selectedLevelData = data.levelName;
                }
                else
                {
                    var randomIndex = Random.Range(0, data.levelData.Count);
                    currentGameData.selectedLevelName = data.levelData[randomIndex];
                    currentGameData.selectedLevelData = data.levelName;
                }

                SceneManager.LoadScene(currentGameData.selectedLevelName);
            }
            else
            {
                for (int index = 0; index < data.levelData.Count; index++)
                {
                    if (data.levelData[index] == currentGameData.selectedLevelName)
                    {
                        var levelIndex = DataSaver.ReadLevelCurrentIndexValues(currentGameData.selectedLevelData);

                        if (levelIndex < data.levelData.Count)
                        {
                            currentGameData.selectedLevelName = data.levelData[levelIndex];
                            currentGameData.selectedLevelData = data.levelName;
                            //SceneManager.LoadScene(currentGameData.selectedLevelName);
                        }
                        else
                        {
                            //SceneManager.LoadScene("SelectLevels");
                            var randomIndex = Random.Range(0, data.levelData.Count);
                            currentGameData.selectedLevelName = data.levelData[randomIndex];
                            currentGameData.selectedLevelData = data.levelName;
                        }
                        SceneManager.LoadScene(currentGameData.selectedLevelName);
                    }
                }
            }
            /*else if (data.levelName == currentGameData.selectedLevelData)
            {
                var levelIndex = DataSaver.ReadLevelCurrentIndexValues(currentGameData.selectedLevelData);

                if (levelIndex < data.levelData.Count)
                {
                    currentGameData.selectedLevelName = data.levelData[levelIndex];
                    currentGameData.selectedLevelData = data.levelName;
                    //SceneManager.LoadScene(currentGameData.selectedLevelName);
                }
                else
                {
                    //SceneManager.LoadScene("SelectLevels");
                    var randomIndex = Random.Range(0, data.levelData.Count);
                    currentGameData.selectedLevelName = data.levelData[randomIndex];
                    currentGameData.selectedLevelData = data.levelName;
                }
                SceneManager.LoadScene(currentGameData.selectedLevelName);
            }*/
        }
    }
}
