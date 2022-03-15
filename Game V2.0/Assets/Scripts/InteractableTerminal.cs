using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableTerminal : MonoBehaviour
{
    private bool inColl = false;
    static public bool LevelPassed = false;
    [SerializeField] private GameObject Box;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inColl)
        {
            Box.SetActive(true);
            //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            LevelPassed = true;
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
