using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3_LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject LevelComplete;
    public GameData gameData;

    void Awake()
    {
        gameData.Golden = true;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        LevelComplete.SetActive(true);
        yield return new WaitForSeconds(1f);
        LevelComplete.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level3");
    }
}
