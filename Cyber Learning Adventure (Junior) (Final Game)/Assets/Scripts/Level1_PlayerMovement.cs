using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1_PlayerMovement : MonoBehaviour
{
    public Level1_HealthBar healthbar;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    private float dirx = 0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpforce = 14f;
    [SerializeField] private GameObject Apple;
    [SerializeField] private Transform elevator;
    [SerializeField] private AudioSource JumpingSound;

    public bool stop;

    public GameData gameData;

    private enum MovementState { idle, running, jumping, falling}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthbar.SetMaxHealth(100);
        healthbar.SetHealth(50);
        stop = false;
        anim.SetInteger("Skin", gameData.CurrentSkin);
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            if(!stop)
            {
                JumpingSound.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }
        if (stop)
            StopPlayerMovement();
        else
            UpdateAnimation();

        if(transform.position.y < -28.5f)
            transform.position = new Vector3(transform.position.x, -26.83f, transform.position.z);

        if (transform.position.x > 156.26f && transform.position.x < 227.85f && GameObject.Find("Hacker").GetComponent<Level2_Hacker_Level2>().choice == 1)
        {
            moveSpeed = 20f;
        }
        else
        {
            moveSpeed = 15f;
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;
        rb.constraints = RigidbodyConstraints2D.None;

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

    private void StopPlayerMovement()
    {
        MovementState state;

        state = MovementState.idle;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Elevator"))
        {
            transform.parent = elevator.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Elevator"))
        {
            transform.parent = null;
        }
    }
}
