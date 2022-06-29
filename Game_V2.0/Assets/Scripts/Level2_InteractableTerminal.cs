using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Level2_InteractableTerminal : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject EnterPass;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI Error;
    [SerializeField] private Level2_HealthBar healthBar;
    public GameData gameData;

    private bool isOpened;
    string path;
    StreamReader reader;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
        Error.enabled = false;
        password = gameData.UserPassword;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            if (!EnterPass.activeSelf)
                button.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = true;
                button.SetActive(false);
                EnterPass.SetActive(true);
            }
        }
        else
            button.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Return) && EnterPass.activeSelf)
        {
            if (inputField.text.Equals(password))
            {
                isOpened = true;
                EnterPass.SetActive(false);
                GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = false;
                Error.enabled = false;
                healthBar.DecHealth(10);
            }
            else
            {
                inputField.Select();
                inputField.text = "";
                Error.enabled = true;
            }
        }
    }

    public bool OpenGate()
    {
        return isOpened;
    }
}
