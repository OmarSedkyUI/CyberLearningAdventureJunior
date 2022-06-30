using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Level3_Terminal : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject button;
    [SerializeField] private Animator Gate;
    [SerializeField] private GameObject PinBox;
    [SerializeField] private TMP_InputField inputField;
    
    int PinCode;
    public bool anonymousComing;

    // Start is called before the first frame update
    void Start()
    {
        PinCode = 52234;
        anonymousComing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            if (!PinBox.activeSelf)
                button.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                button.SetActive(false);
                PinBox.SetActive(true);
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
            }
            if (PinBox.activeSelf && Input.GetKeyDown(KeyCode.Return))
            {
                if (inputField.text == PinCode.ToString())
                {
                    Gate.SetBool("IsOpening", true);
                    PinBox.SetActive(false);
                    GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
                }
                else
                {
                    PinBox.SetActive(false);
                    GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
                    anonymousComing = true;
                }
            }
        }
        else
            button.SetActive(false);

        if(player.position.x > 84f)
        {
            Gate.SetBool("IsOpening", false);
        }
    }
}
