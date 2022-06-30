using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3_Anonymous : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform dest;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines1;
    [SerializeField] private string[] lines2;
    private int index1;
    private int index2;
    private SpriteRenderer sp;
    private Animator anim;
    public float speed;
    private bool conv2;
    private bool endConv;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        index1 = 0;
        index2 = 0;
        conv2 = false;
        endConv = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x)
            sp.flipX = false;
        else
            sp.flipX = true;

        if (Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            if(!dialogue.activeSelf && !endConv)
                button.SetActive(true);
            Conversation();
        }
        else
            button.SetActive(false);

        if(GameObject.Find("Terminal").GetComponent<Level3_Terminal>().anonymousComing)
        {
            var step = speed * Time.deltaTime;
            sp.flipX = false;
            anim.SetBool("IsRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, dest.position, step);
        }

        if(transform.position == dest.position)
        {
            GameObject.Find("Terminal").GetComponent<Level3_Terminal>().anonymousComing = false;
            anim.SetBool("IsRunning", false);
            conv2 = true;
        }
            
    }

    void Conversation()
    {
        if (Input.GetKeyDown(KeyCode.E) && !conv2)
        {
            button.SetActive(false);
            dialogue.SetActive(true);
            if (index1 >= lines1.Length)
            {
                dialogue.SetActive(false);
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
            }
            else
            {
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
                text.text = lines1[index1];
            }
            index1 += 1;
        }

        if (Input.GetKeyDown(KeyCode.E) && conv2)
        {
            button.SetActive(false);
            dialogue.SetActive(true);
            if (index2 >= lines2.Length)
            {
                dialogue.SetActive(false);
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
                endConv = true;
            }
            else
            {
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
                text.text = lines2[index2];
            }
            index2 += 1;
        }
    }

}
