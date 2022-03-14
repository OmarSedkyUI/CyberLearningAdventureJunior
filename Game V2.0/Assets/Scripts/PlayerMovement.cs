using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirx =0f;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpforce = 14f;

    private enum MovementState { idle, running, jumping, falling}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hacker"))
        {
            Dialogue.SetActive(true);
            //moveSpeed = 0f;
            //jumpforce = 0f;
            StartCoroutine(DisableDialogue());
        }
    }

    IEnumerator DisableDialogue()
    {
        yield return new WaitForSeconds(2);
        Dialogue.SetActive(false);
        //moveSpeed = 7f;
        //jumpforce = 14f;
    }
}
