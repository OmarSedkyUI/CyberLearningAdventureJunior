using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2_CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform hacker;
    [SerializeField] private Transform CamDest;
    [SerializeField] private GameObject FightGame;
    [SerializeField] private GameObject FinalDialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject UI;

    [SerializeField] private string[] lines;
    private float dirx = 0f;
    private float moveSpeed = 15f;
    Rigidbody2D rb;
    private bool oneTime;
    private int index;
    Animator anim;
    bool stopFighting;

    private void Start()
    {
        UI.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        
        oneTime = true;
        index = 1;
        stopFighting = false;
    }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if(MainMenu.activeSelf)
        {
            transform.position = new Vector3(-9.8f, player.position.y + 4, transform.position.z);
            GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = true;
        }
        else
        {
            if (player.position.x < 0f)
            {
                transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
            }

            else if (Vector2.Distance(player.position, hacker.position) < 25.60f && player.position.x > 400f)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = true;
                transform.position = Vector3.MoveTowards(transform.position, CamDest.position, 12 * Time.deltaTime);
                if (oneTime)
                    StartCoroutine(fighting());
            }

            else
            {
                transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
            }
        }

        if (player.position.x > 301.2252f)
        {
            Camera.main.orthographic = false;
            if(Camera.main.fieldOfView <= 100 && dirx > 0f)
            {
                Camera.main.fieldOfView += 0.02f;
            }
        }    

        if (!oneTime)
        {
            if(!stopFighting)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (index >= lines.Length)
                    {
                        FinalDialogue.SetActive(false);
                        FightGame.SetActive(true);
                        stopFighting = true;
                    }
                    else
                        text.text = lines[index];
                    index += 1;
                }
            }
        }
    }

    IEnumerator fighting()
    {
        oneTime = false;
        text.text = lines[0];
        yield return new WaitForSecondsRealtime(1.5f);
        FinalDialogue.SetActive(true);
    }
    public void PressPlay()
    {
        anim.Play("Level2_CameraAnimation", 0);
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        MainMenu.SetActive(false);
        UI.SetActive(true);
        StartCoroutine(Wait(info));
    }

    IEnumerator Wait(AnimatorStateInfo info)
    {
        yield return new WaitForSeconds(info.length);
        GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().stop = false;
        anim.enabled = false;
    }
}
