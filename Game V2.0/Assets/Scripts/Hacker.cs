using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hacker : MonoBehaviour
{
    private SpriteRenderer hacker;
    private int index;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines;


    // Start is called before the first frame update
    void Start()
    {
        hacker = GetComponent<SpriteRenderer>();
        index = 0;
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

        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 5f)
        {
            if (index >= lines.Length)
            {
                Dialogue.SetActive(false);
                index = 0;
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            }
            else
            {
                Dialogue.SetActive(true);
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                text.text = lines[index];
            }
            index += 1;
        }
        else if (Vector2.Distance(player.position, transform.position) > 5f && Vector2.Distance(player.position, transform.position) < 7.5f)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Dialogue.SetActive(false);
        }
    }
}
