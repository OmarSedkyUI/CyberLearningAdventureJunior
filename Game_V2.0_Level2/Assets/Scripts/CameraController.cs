using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform hacker;
    [SerializeField] private Transform CamDest;
    [SerializeField] private GameObject FightGame;
    [SerializeField] private GameObject FinalDialogue;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private string[] lines;
    private float dirx = 0f;
    private float moveSpeed = 15f;
    public Camera cam;
    public float defaultCam;
    Rigidbody2D rb;
    private bool oneTime;
    private int index;

    private void Start()
    {
        defaultCam = GetComponent<Camera>().orthographicSize;
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        oneTime = true;
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if (player.position.x <= -0.02f)
        {
            transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
        }
        else if(Vector2.Distance(player.position, hacker.position) < 25.60f && player.position.x > 400f)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            GameObject.Find("Player").GetComponent<PlayerMovement>().stop = true;
            transform.position = Vector3.MoveTowards(transform.position, CamDest.position, 12 * Time.deltaTime);
            if(oneTime)
                StartCoroutine(fighting());
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
        }

        if (player.position.x > 301.2252f && player.position.x < 432f && GetComponent<Camera>().orthographicSize <= 11.63 && dirx > 0f)
            GetComponent<Camera>().orthographicSize += 0.005f;
        else if(player.position.x > 432f && GetComponent<Camera>().orthographicSize >= defaultCam + 2)
            GetComponent<Camera>().orthographicSize -= 0.02f;

        if(!oneTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (index >= lines.Length)
                {
                    FinalDialogue.SetActive(false);
                    FightGame.SetActive(true);
                }
                else
                    text.text = lines[index];
                index += 1;
            }
        }
    }

    IEnumerator fighting()
    {
        oneTime = false;
        text.text = lines[0];
        yield return new WaitForSecondsRealtime(1.5f);
        Debug.Log("HERE");
        FinalDialogue.SetActive(true);
        
    }
}
