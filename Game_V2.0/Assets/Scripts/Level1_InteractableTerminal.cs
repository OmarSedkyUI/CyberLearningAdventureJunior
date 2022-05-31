using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1_InteractableTerminal : MonoBehaviour
{
    private bool isopened = false;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject Box;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI Error;
    [SerializeField] private GameObject button;

    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2f && !Box.activeSelf)
        {
            button.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 2f)
        {
            Box.SetActive(true);
            button.SetActive(false);
            Error.enabled = true;
            GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().stop = true;
        }
        else if (Vector2.Distance(player.position, transform.position) > 2f && Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().stop = false;
            Box.SetActive(false);
            button.SetActive(false);
        }

        if (inputField.text == "")
        {
            Error.enabled = true;
        }
        else
        {
            Error.enabled = false;
        }

        if (Box.activeSelf && Input.GetKeyDown(KeyCode.Return) && !Error.enabled && Vector2.Distance(player.position, transform.position) < 1.5f)
        {
            Level1_Passwords.Pass = inputField.text;
            Box.SetActive(false);
            GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().stop = false;
            isopened = true;
            enabled = false;
        }
    }

    public bool OpenGate()
    {
        return isopened;
    }
}