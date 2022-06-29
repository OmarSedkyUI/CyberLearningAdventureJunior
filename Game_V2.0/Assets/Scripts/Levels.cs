using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    private bool Level_2;
    private bool Level_3;
    private string sceneName;
    [SerializeField] private Button Prev;
    [SerializeField] private Button Next;
    public GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        Level_2 = gameData.Level2;
        Level_3 = gameData.Level3;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        Level_2 = gameData.Level2;
        Level_3 = gameData.Level3;
        
        if(sceneName == "Level1")
        {
            Prev.enabled = false;
        }

        if(sceneName == "Level3")
        {
            Next.enabled = false;
        }
    }

    public void PrevBtn()
    {
        if(sceneName == "Level2")
        {
            SceneManager.LoadScene("Level1");
        }
        else if(sceneName == "Level3")
        {
            SceneManager.LoadScene("Level2");
        }
    }

    public void NextBtn()
    {

        if(sceneName == "Level1" && Level_2)
        {
            SceneManager.LoadScene("Level2");
        }
        else if(sceneName == "Level2" && Level_3)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    public void SkinsBtn()
    {
        gameData.LastScene = sceneName;
        SceneManager.LoadScene("Skins");
    }
}

