using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableTerminal : MonoBehaviour
{
    public HealthBar healthbar;
    private bool inColl = false;
    static public bool LevelPassed = false;
    static public int Levels;
    [SerializeField] private GameObject Box;
    [SerializeField] private string Level;
    [SerializeField] private TMP_InputField inputField;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inColl)
        {
            Box.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            //LevelPassed = true;
        }
        if(Box.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            if (Level.Equals("PasswordChecker"))
            {
                Levels = Password.PasswordChecker(inputField.text);
                LevelPassed = Password.LevelPassed;
            }
            Box.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            healthbar.SetHealth(25);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inColl = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Box.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        inColl = false;
    }
}
