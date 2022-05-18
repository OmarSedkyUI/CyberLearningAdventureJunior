using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Terminal_2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject Anonymos;
    [SerializeField] private GameObject ChatBot;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_InputField inputField;
    private bool isOpened;

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
                GameObject.Find("Player").GetComponent<PlayerMovement>().stop = true;
                Anonymos.SetActive(true);
                StartCoroutine(StartChatBot());
            }
            if (Input.GetKeyDown(KeyCode.Return) && !ChatBot.activeSelf)
            {
                Password.Pass = inputField.text;
                if (Password.LengthCheck() && Password.SpecialCheck() && Password.CommonPassCheck())
                {
                    GameObject.Find("Player").GetComponent<PlayerMovement>().stop = false;
                    Anonymos.SetActive(false);
                    isOpened = true;
                    string path = "D:/CyberLearningAdventureJunior/Game_V2.0_Level2/Assets/UserPassword.txt";
                    StreamWriter writer = new StreamWriter(path, false);
                    writer.WriteLine(Password.Pass);
                    writer.Close();
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
