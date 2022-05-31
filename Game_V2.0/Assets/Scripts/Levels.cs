using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public bool Level_2;
    public bool Level_3;
    private string sceneName;
    [SerializeField] private Button Prev;
    [SerializeField] private Button Next;
    // Start is called before the first frame update
    void Start()
    {
        Level_2 = StaticLevel.Level_2;
        Level_3 = StaticLevel.Level_3;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
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
}

public static class StaticLevel
{
    public static bool Level_2 = false;
    public static bool Level_3 = false;
}