using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTerminal2 : MonoBehaviour
{
    private bool inColl = false;
    [SerializeField] private GameObject Box;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inColl)
        {
            Box.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }

        if (Box.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            Box.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
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
