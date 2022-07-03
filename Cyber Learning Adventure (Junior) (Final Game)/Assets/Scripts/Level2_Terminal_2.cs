using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Level2_Terminal_2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject Anonymos;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI Error1;
    [SerializeField] private TextMeshProUGUI Error2;

    private bool isOpened;

    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2.5f && !isOpened)
        {
            button.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = true;
                Anonymos.SetActive(true);
                Error1.enabled = false;
                Error2.enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Level2_Password.Pass = inputField.text;
                if (Level2_Password.LengthCheck() && Level2_Password.SpecialCheck() && Level2_Password.CommonPassCheck() && inputField.text != gameData.UserPassword)
                {
                    Error1.enabled = false;
                    Error2.enabled = false;
                    GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = false;
                    Anonymos.SetActive(false);
                    isOpened = true;
                    gameData.UserPassword = Level2_Password.Pass;
                }
                else if(inputField.text == gameData.UserPassword)
                {
                    Error1.enabled = false;
                    Error2.enabled = true;
                }
                else
                {
                    Error1.enabled = true;
                    Error2.enabled = false;
                }
            }
        }
        else
            button.SetActive(false);
    }

    public bool OpenGate()
    {
        return isOpened;
    }
}
