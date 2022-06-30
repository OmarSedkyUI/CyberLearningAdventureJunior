using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3_Anonymous : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform dest;
    [SerializeField] private Transform dest2;
    [SerializeField] private Transform dest3;
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
    private bool conv1;
    private bool conv2;
    private bool conv3;
    private bool endConv;
    private bool oneTime;
    private bool oneTime2;
    public bool run2;
    [SerializeField] private GameObject ChatBot;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        index1 = 0;
        index2 = 0;
        conv1 = true;
        conv2 = false;
        conv3 = false;
        endConv = false;
        oneTime = true;
        oneTime2 = true;
        run2 = false;
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

        if (GameObject.Find("Terminal").GetComponent<Level3_Terminal>().anonTeleport)
        {
            transform.position = dest2.position;
            GameObject.Find("Terminal").GetComponent<Level3_Terminal>().anonTeleport = false;
        }

        if (transform.position == dest.position)
        {
            GameObject.Find("Terminal").GetComponent<Level3_Terminal>().anonymousComing = false;
            anim.SetBool("IsRunning", false);
            conv1 = false;
            if (oneTime)
            {
                conv2 = true;
                endConv = false;
                oneTime = false;
            }
        }

        if (transform.position == dest2.position)
        {
            conv1 = false;
            if (oneTime2)
            {
                conv3 = true;
                endConv = false;
                oneTime2 = false;
            }
        }

        if(run2)
        {
            var step = speed * Time.deltaTime;
            sp.flipX = false;
            anim.SetBool("IsRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, dest3.position, step);
        }

        if (transform.position == dest3.position)
        {
            anim.SetBool("IsRunning", false);
            gameObject.SetActive(false);
            run2 = false;
        }
    }

    void Conversation()
    {
        if (Input.GetKeyDown(KeyCode.E) && conv1 && !conv2 && !conv3 && !ChatBot.activeSelf)
        {
            button.SetActive(false);
            dialogue.SetActive(true);
            if (index1 >= lines1.Length)
            {
                dialogue.SetActive(false);
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
                endConv = true;
            }
            else
            {
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
                text.text = lines1[index1];
            }
            index1 += 1;
        }

        if (Input.GetKeyDown(KeyCode.E) && conv2 && !conv3 && !ChatBot.activeSelf)
        {
            button.SetActive(false);
            dialogue.SetActive(true);
            if (index2 >= lines2.Length)
            {
                dialogue.SetActive(false);
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
                endConv = true;
                conv2 = false;
            }
            else if (index2 == 2)
            {
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
                text.text = lines2[index2] + GameObject.Find("Terminal").GetComponent<Level3_Terminal>().PinCode.ToString();
            }
            else
            {
                GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
                text.text = lines2[index2];
            }
            index2 += 1;
        }

        if (Input.GetKeyDown(KeyCode.E) && !conv2 && conv3 && !ChatBot.activeSelf)
        {
            button.SetActive(false);
            GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
            conv3 = false;
            StartChatBot();
        }
    }

    private void StartChatBot()
    {
        ChatBot.SetActive(true);
        gameManager.StartBot();
        endConv = true;
    }

}
