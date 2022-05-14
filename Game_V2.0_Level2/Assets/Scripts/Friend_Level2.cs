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
            StartCoroutine(ConvWithFriend());
        }

        if (!IsGrounded())
            anim.SetBool("IsFalling", true);
        else
            anim.SetBool("IsFalling", false);
    }

    void Conversation()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            button.SetActive(false);
            dialogue.SetActive(true);
            if (index >= lines.Length)
            {
                dialogue.SetActive(false);
                index = 3;
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            }
            else if(index > 2 && showChoice)
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
        }
    }

    IEnumerator ConvWithFriend()
    {
        yield return new WaitForSecondsRealtime(1);
        coll.isTrigger = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
