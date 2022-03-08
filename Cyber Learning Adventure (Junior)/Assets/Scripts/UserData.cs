using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserData : MonoBehaviour
{
    public UserInfo userInfo;
    public TMP_InputField inputField;
    private string Input;
    public void Button()
    {
        Input = inputField.text;
        userInfo.userName = Input;

        SceneManager.LoadScene("MainMenu");
    }
}
