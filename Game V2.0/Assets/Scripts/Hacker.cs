using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hacker : MonoBehaviour
{
    private SpriteRenderer hacker;
    private bool inColl = false;
    private int index;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines;


    // Start is called before the first frame update
    void Start()
    {
        hacker = GetComponent<SpriteRenderer>();
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < 27.81)
        {
            hacker.flipX = true;
        }
        else
        {
            hacker.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && inColl)
        {
            if(index >= lines.Length)
            {
                Dialogue.SetActive(false);
            }
            else
            {
                text.text = lines[index];
            }
            index += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dialogue.SetActive(true);
        inColl = true;
        text.text = lines[0];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Dialogue.SetActive(false);
        inColl = false;
        index = 1;
    }
}
