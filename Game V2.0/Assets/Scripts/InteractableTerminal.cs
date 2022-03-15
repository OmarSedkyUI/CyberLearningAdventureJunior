using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableTerminal : MonoBehaviour
{
    private bool inColl = false;
    static public bool LevelPassed = false;
    private int index;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inColl)
        {
            if (index >= lines.Length)
            {
                Dialogue.SetActive(false);
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                LevelPassed = true;
            }
            else
            {
                Dialogue.SetActive(true);
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                text.text = lines[index];
            }
            index += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inColl = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Dialogue.SetActive(false);
        inColl = false;
        index = 0;
    }
}
