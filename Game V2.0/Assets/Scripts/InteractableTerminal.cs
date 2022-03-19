using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableTerminal : MonoBehaviour
{
    private bool isopened = false;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject Box;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI Error;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 1.5f)
        {
            Box.SetActive(true);
            Error.enabled = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }
        else if (Vector2.Distance(player.position, transform.position) > 1.5f && Vector2.Distance(player.position, transform.position) < 2f)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Box.SetActive(false);
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
            Passwords.Pass = inputField.text;
            Passwords.LengthCheck();
            Box.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            isopened = true;
            enabled = false;
        }
    }

    public bool OpenGate()
    {
        return isopened;
    }
}