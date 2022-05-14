using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hacker_Level2 : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject ChoiceBox;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Transform target;
    [SerializeField] private Transform friend;
    public HealthBar healthbar;
    private Animator anim;
    private SpriteRenderer sp;
    public float speed;
    private bool oneTime;
    public int choice;
    public bool FriendAppear;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        oneTime = true;
        FriendAppear = false;
        choice = 0;
    }

    private void Update()
    {
        if(choice == 1)
            StartCoroutine(Escape1());
        else if(choice == 2)
            StartCoroutine(Escape2());

        if(!oneTime)
        {
            var step = speed * Time.deltaTime;
            sp.flipX = false;
            anim.SetBool("IsRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            StartCoroutine(Escape3());
        }
     
        if (transform.position == target.position)
        {
            anim.SetBool("IsRunning", false);
            sp.flipX = true;
            FriendAppear = true;
        }
    }
    public void AcceptRequest()
    {
        ChoiceBox.SetActive(false);
        friend.position = new Vector3(-19.3083f, -2.019091f, friend.position.z);
        transform.position = new Vector3(46.23f, -2.019091f, transform.position.z);
        choice = 1;
        
    }
    public void RejectRequest()
    {
        ChoiceBox.SetActive(false);
        friend.position = new Vector3(-19.3083f, -2.019091f, friend.position.z);
        transform.position = new Vector3(46.23f, -2.019091f, transform.position.z);
        choice = 2;
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
        yield return new WaitForSecondsRealtime(2);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }
}
