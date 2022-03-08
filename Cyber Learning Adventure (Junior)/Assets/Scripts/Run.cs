using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run : MonoBehaviour
{
    public UserInfo userInfo;
    void Start()
    {
        if (string.IsNullOrEmpty(userInfo.userName))
        {
            SceneManager.LoadScene("UserInfo");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
