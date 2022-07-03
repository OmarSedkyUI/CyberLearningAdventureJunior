using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject LevelComplete;
    public GameData gameData;

    void Awake()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        LevelComplete.SetActive(false);
        yield return new WaitForSeconds(1f);
        gameData.Level3 = true;
        SceneManager.LoadScene("Level3");
    }
}
