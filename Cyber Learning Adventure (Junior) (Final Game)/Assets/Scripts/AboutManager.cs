using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutManager : MonoBehaviour
{
    public GameData gameData;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (string.IsNullOrEmpty(gameData.LastScene))
            {
                gameData.LastScene = "Level1";
            }
            SceneManager.LoadScene(gameData.LastScene);
        }
    }
}
