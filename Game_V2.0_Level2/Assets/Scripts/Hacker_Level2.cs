using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hacker_Level2 : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject dialogue2;
    [SerializeField] private GameObject ChoiceBox;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private Transform dest_2;
    [SerializeField] private Transform friend;
    [SerializeField] private string[] lines;
    private int index;
    public HealthBar healthbar;
    private Animator anim;
    private SpriteRenderer sp;
    public float speed;
    private bool oneTime;
    public int choice;
    public bool FriendAppear;
    public bool transition;
    private bool atPosition;
    private bool atPosition_2;
    private bool conv;
    public bool passwrodStolen;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        oneTime = true;
        FriendAppear = false;
        transition = true;
        atPosition = false;
        atPosition_2 = false;
        passwrodStolen = false;
        conv = true;
        choice = 0;
        index = 0;
    }

    private void Update()
    {
        if(choice == 1)
            StartCoroutine(Escape1());
        else if(choice == 2)
            StartCoroutine(Escape2());

        if (player.position.x > transform.position.x)
            sp.flipX = false;
        else
            sp.flipX = true;

        if (!oneTime)
        {
            if (!atPosition)
            {
                var step = speed * Time.deltaTime;
                sp.flipX = false;
                anim.SetBool("IsRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }  
        }
     
        if (transform.position == target.position && !atPosition)
        {
            anim.SetBool("IsRunning", false);
            FriendAppear = true;
            atPosition = true;
            transform.position = new Vector3(206.8191f, -17.01898f, transform.position.z);
           
        }

        if(!dialogue.activeSelf && index >= lines.Length)
        {
            if (!atPosition_2)
            {
                var step = speed * Time.deltaTime;
                sp.flipX = false;
                anim.SetBool("IsRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, dest_2.position, step);
                
                GameObject.Find("Player").GetComponent<PlayerMovement>().stop = false;
            }
        }

        if (transform.position == dest_2.position && !atPosition_2)
        {
            anim.SetBool("IsRunning", false);
            friend.position = new Vector3(193.7617f, -17.01898f, friend.position.z);
            atPosition_2 = true; 
            passwrodStolen = true;
            transform.position = new Vector3(457.6f, 13.981f, transform.position.z);

        }
        else if(player.position.x > dest_2.position.x)
        {
            transform.position = new Vector3(457.6f, 13.981f, transform.position.z);
        }

        if (player.position.x > 199.6042f && choice == 2 && conv)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().stop = true;
            text2.text = lines[index];
            dialogue2.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                index += 1;
                if (index >= lines.Length)
                {
                    dialogue2.SetActive(false);
                    conv = false;

                }
                else
                {
                    text2.text = lines[index];
                }
            }

        }
    }
    public void AcceptRequest()
    {
        if(transition)
        {
            ChoiceBox.SetActive(false);
            friend.position = new Vector3(-19.3083f, -2.019091f, friend.position.z);
            transform.position = new Vector3(46.23f, -2.019091f, transform.position.z);
            choice = 1;
            transition = false;
        }
        
        
    }
    public void RejectRequest()
    {
        if(transition)
        {
            ChoiceBox.SetActive(false);
            friend.position = new Vector3(-19.3083f, -2.019091f, friend.position.z);
            transform.position = new Vector3(46.23f, -2.019091f, transform.position.z);
            choice = 2;
            transition = false;
        }
    }

    IEnumerator Escape1()
    {
        if(oneTime)
        {
            text.text = "HAHAHAHAHAHA";
            healthbar.SetHealth(50);
            dialogue.SetActive(true);
            yield return new WaitForSecondsRealtime(1);
            dialogue.SetActive(false);
            oneTime = false;
        }
    }
    IEnumerator Escape2()
    {
        if (oneTime)
        {
            text.text = "How did you know?!";
            dialogue.SetActive(true);
            yield return new WaitForSecondsRealtime(1);
            dialogue.SetActive(false);
            oneTime = false;
        }
    }

    IEnumerator Escape3()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().stop = false;
    }
}
