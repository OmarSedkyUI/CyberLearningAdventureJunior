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
            SceneManager.LoadScene(gameData.LastScene);
        }
    }
}
