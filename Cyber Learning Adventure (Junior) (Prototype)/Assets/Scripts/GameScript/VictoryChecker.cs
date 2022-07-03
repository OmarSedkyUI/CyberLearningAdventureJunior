using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryChecker : MonoBehaviour
{
    public bool Complete = false;
    public bool Correct = false;
    public GameData currentGameData;
    public GameLevelData gameLevelData;
    public UserInfo userInfo;

    private void OnEnable()
    {
        GameEvents.OnLoadNextLevel += LoadNextLevel;
    }

    private void OnDisable()
    {
        GameEvents.OnLoadNextLevel -= LoadNextLevel;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Button(bool Victory)
    {
        //DataSaver.ClearGameData(gameLevelData); //Clear Progress

        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;*/

        //Correct = PasswordChecker.Checker(sceneName, userInfo.userName, "Password");

        //Correct = true;

        Correct = Victory;
        CheckCorrect();
    }

    private void CheckCorrect()
    {
        if(Correct)
        {
            Complete = true;
            CheckCompleted();
        }
        else
        {
            SceneManager.LoadScene("LosePopUpScene");
        }
    }

    private void CheckCompleted()
    {
        bool loadNextLevel = false;

        if (Complete)
        {
            var levelName = currentGameData.selectedLevelData;
            var currentLevelIndex = DataSaver.ReadLevelCurrentIndexValues(levelName);
            var nextLevelIndex = -1;
            var currentPuzzleIndex = 0;
            bool readNextLevelName = false;

            for (int i = 0; i < gameLevelData.data.Count; i++)
            {
                if (readNextLevelName)
                {
                    nextLevelIndex = DataSaver.ReadLevelCurrentIndexValues(gameLevelData.data[i].levelName);
                    readNextLevelName = false;
                }

                if (gameLevelData.data[i].levelName == levelName)
                {
                    readNextLevelName = true;
                    currentPuzzleIndex = i;
                }
            }

            var currentLevelSize = gameLevelData.data[currentPuzzleIndex].levelData.Count;
            if (currentLevelIndex < currentLevelSize)
                currentLevelIndex += 1;

            DataSaver.SaveLevelData(levelName, currentLevelIndex);

            //Unlock Next Puzzle
            if (currentLevelIndex >= currentLevelSize)
            {
                currentPuzzleIndex++;
                if (currentPuzzleIndex < (gameLevelData.data.Count - 1)) //Not Last Puzzle
                {
                    levelName = gameLevelData.data[currentPuzzleIndex].levelName;
                    currentLevelIndex = 0;
                    loadNextLevel = true;

                    if (nextLevelIndex <= 0)
                    {
                        DataSaver.SaveLevelData(levelName, currentLevelIndex);
                    }
                }
                else
                {
                    SceneManager.LoadScene("WinPopUpScene");
                    //SceneManager.LoadScene("SelectLevels");
                }
            }
            else
            {
                SceneManager.LoadScene("WinPopUpScene");
                //GameEvents.LevelCompletedMethod();
            }

            if (loadNextLevel)
            {
                SceneManager.LoadScene("WinPopUpScene");
                //GameEvents.UnlockNextPuzzleMethod();
            }
        }
    }
}
