using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Friend_Level2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject ChoiceBox;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines;
    private int index;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > 46.23003)
            sp.flipX = false;
        else
            sp.flipX = true;

        if (Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            button.SetActive(true);
            Conversation();
        }
        else
            button.SetActive(false);
    }

    void Conversation()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            button.SetActive(false);
            dialogue.SetActive(true);
            if (index >= lines.Length - 1)
            {
                dialogue.SetActive(false);
                ChoiceBox.SetActive(true);
            }
            else
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                text.text = lines[index];
            }
            index += 1;
        }
    }
}
