using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopUp : MonoBehaviour
{
    public GameObject winPopUp;

    void Start()
    {
        //winPopUp.SetActive(false);
    }

    private void OnEnable()
    {
        GameEvents.OnLevelCompleted += ShowWinPopUp;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelCompleted -= ShowWinPopUp;
    }

    private void ShowWinPopUp()
    {
        winPopUp.SetActive(true);
    }

    public void LoadNextLevel()
    {
        //GameEvents.LoadNextLevelMethod();
    }
}
