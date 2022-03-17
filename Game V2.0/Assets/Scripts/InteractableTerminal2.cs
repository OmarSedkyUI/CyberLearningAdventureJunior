using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTerminal2 : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] private Transform player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 1.5f)
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
}
