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
    [SerializeField] private LayerMask jumpableGround;
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private bool showChoice;
    private bool oneTime;
    int Choice;
    private bool Repeat = true;
    int Size;
    int EPress;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        showChoice = true;
        index = 0;
        oneTime = true;
        Size = lines.Length;
        EPress = 4;
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

        if (GameObject.Find("Hacker").GetComponent<Hacker_Level2>().FriendAppear && oneTime)
        {
            transform.position = new Vector3(46.23f, 9.42f, transform.position.z);
            rb.constraints = RigidbodyConstraints2D.None;
            coll.isTrigger = false;
            oneTime = false;
        }

        if (IsGrounded())
        {
            Choice = GameObject.Find("Hacker").GetComponent<Hacker_Level2>().choice;
            if (Choice == 1 && Repeat)
            {
                index = 3;
                int LinesNo = 2;
                Size = index + LinesNo;
                Repeat = false;
                EPress = 3;
            }
            else if (Choice == 2 && Repeat)
            {
                index = 5;
                Repeat = false;
                EPress = 2;
            }
            StartCoroutine(ConvWithFriend());
        }

        if (!IsGrounded())
            anim.SetBool("IsFalling", true);
        else
            anim.SetBool("IsFalling", false);
    }

    void Conversation()
    {
        if (Input.GetKeyDown(KeyCode.E) && EPress != 0)
        {
            button.SetActive(false);
            dialogue.SetActive(true);
            if (index >= Size)
            {
                dialogue.SetActive(false);
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                Repeat = true;
            }
            else if (index > 2 && showChoice)
            {
                dialogue.SetActive(false);
                ChoiceBox.SetActive(true);
                showChoice = false;
            }
            else
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                text.text = lines[index];
            }
            index += 1;
            EPress -= 1;
        }
    }

    IEnumerator ConvWithFriend()
    {
        yield return new WaitForSecondsRealtime(1);
        coll.isTrigger = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
