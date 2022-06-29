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
    [SerializeField] private GameObject ChatBot;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_InputField inputField;
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
        if (Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            button.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = true;
                Anonymos.SetActive(true);
                StartCoroutine(StartChatBot());
            }
            if (Input.GetKeyDown(KeyCode.Return) && !ChatBot.activeSelf)
            {
                Level2_Password.Pass = inputField.text;
                if (Level2_Password.LengthCheck() && Level2_Password.SpecialCheck() && Level2_Password.CommonPassCheck())
                {
                    GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = false;
                    Anonymos.SetActive(false);
                    isOpened = true;
                    gameData.UserPassword = Level2_Password.Pass;
                }
            }
        }
        else
            button.SetActive(false);
    }

    IEnumerator StartChatBot()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        ChatBot.SetActive(true);
        gameManager.StartBot();
    }

    public bool OpenGate()
    {
        return isOpened;
    }
}
