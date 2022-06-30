using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3_Friend : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines;


    private SpriteRenderer sp;
    private int index;
    private bool oneTime;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        index = 1;
        text.text = lines[0];
        oneTime = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(player.position.x >= 140f)
        {
            GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
            if (GameObject.Find("Main Camera").GetComponent<Level3_CameraController>().destReached && oneTime)
            {
                dialogue.SetActive(true);
                oneTime = false;
            }
            Conversation();
        }
        
    }

    void Conversation()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogue.activeSelf)
        {
            if (index >= lines.Length)
            {
                dialogue.SetActive(false);
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
            }
            else
            {
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
                text.text = lines[index];
            }
            index += 1;
        }
       
    }
}
