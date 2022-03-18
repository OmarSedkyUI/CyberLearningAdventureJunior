using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Terminals : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject Box;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI Error;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 1.5f)
        {
            Box.SetActive(true);
            Error.enabled = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }

        if (inputField.text == "")
        {
            Error.enabled = true;
        }
        else
        {
            Error.enabled = false;
        }

        if (Box.activeSelf && Input.GetKeyDown(KeyCode.Return) && !Error.enabled)
        {
            Debug.Log("Entered terminals");
            Box.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
