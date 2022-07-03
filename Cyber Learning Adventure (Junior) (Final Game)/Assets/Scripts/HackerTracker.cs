using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HackerTracker : MonoBehaviour
{
    public GameObject Error;
    public GameData gameData;
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;
    private string userTxt;
    private string passTxt;
    public Level3_HealthBar healthBar;

    private void Awake()
    {
        Error.SetActive(false); 
    }
    void Update()
    {
        if(gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrEmpty(username.text) && !string.IsNullOrEmpty(password.text))
        {
            userTxt = username.text;
            passTxt = password.text;

            if (userTxt.Equals(gameData.UserUsername) && passTxt.Equals(gameData.UserPassword))
            {
                Error.SetActive(false);
                healthBar.SetHealth(0);
            }
            else
                Error.SetActive(true);
        }
        else if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Error.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
