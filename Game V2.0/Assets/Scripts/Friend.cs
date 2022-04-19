using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Friend : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform CamPos2;
    [SerializeField] private GameObject Box;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines1;
    [SerializeField] private string[] lines2;
    [SerializeField] private string[] lines3;
    [SerializeField] private string[] lines4;
    [SerializeField] private string[] lines5;
    private int index;
    private int index2;
    [SerializeField] private GameObject button;
    [SerializeField] private Transform cam;
    static public bool FriendDialogue;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        FriendDialogue = false;
        text.text = lines5[0];
        index = 0;
        index2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y <= -1.018977f && player.position.y >= -3.018977f)
        {
            transform.position = new Vector3(27.54f, -2.018974f, transform.position.z);
            if (player.position.x > 27.54f)
                sp.flipX = false;
            else
                sp.flipX = true;

            if (Vector2.Distance(player.position, transform.position) < 2f)
            {
                button.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    button.SetActive(true);
                    Box.SetActive(true);
                    if (index >= lines1.Length)
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                        index = -1;
                        text.text = lines5[0];
                        Box.SetActive(false);
                    }
                    else
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                        text.text = lines1[index];
                    }
                    index += 1;
                }
            }
            else if(Vector2.Distance(player.position, transform.position) > 2f)
                button.SetActive(false);
        }


        if (player.position.y <= -27.01895f && player.position.y >= -29.01895f)
        {
            transform.position = new Vector3(114.53f, -28.01898f, transform.position.z);
            if (player.position.x > 114.53f)
                sp.flipX = false;
            else
                sp.flipX = true;

            if (Vector2.Distance(player.position, transform.position) < 2f)
            {
                button.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    button.SetActive(true);
                    Box.SetActive(true);
                    if (index >= lines2.Length)
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                        index = -1;
                        text.text = lines5[0];
                        Box.SetActive(false);
                    }
                    else
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                        text.text = lines2[index];
                    }
                    index += 1;
                }
            }
            else if (Vector2.Distance(player.position, transform.position) > 2f)
                button.SetActive(true);
        }


        if (player.position.y <= -14.01903f && player.position.y >= -16.01903f)
        {
            transform.position = new Vector3(114.53f, -15.01903f, transform.position.z);
            if (player.position.x > 114.53f)
                sp.flipX = false;
            else
                sp.flipX = true;

            if (Vector2.Distance(player.position, transform.position) < 2f)
            {
                button.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    button.SetActive(true);
                    Box.SetActive(true);
                    if (index >= lines3.Length)
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                        index = -1;
                        text.text = lines5[0];
                        Box.SetActive(false);
                    }
                    else
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                        text.text = lines3[index];
                    }
                    index += 1;
                }
            }
            else if (Vector2.Distance(player.position, transform.position) > 2f)
                button.SetActive(false);
        }


        if (player.position.y <= 11.98098f && player.position.y >= 9.98098f)
        {
            transform.position = new Vector3(114.53f, 10.98097f, transform.position.z);
            if (player.position.x > 114.53f)
                sp.flipX = false;
            else
                sp.flipX = true;
            if (Vector2.Distance(player.position, transform.position) < 2f)
            {
                if(Box.activeSelf)
                    button.SetActive(false);
                else
                    button.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Box.SetActive(true);
                    if (index >= lines4.Length)
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                        index = -1;
                        text.text = lines5[0];
                        Box.SetActive(false);

                    }
                    else
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                        text.text = lines4[index];
                    }
                    index += 1;
                }
            }
            else if (Vector2.Distance(player.position, transform.position) > 2f)
                button.SetActive(false);
        }


        if (player.position.y <= 44.98097f && player.position.y >= 42.98097f)
            


        if( Vector2.Distance(CamPos2.position, cam.position) < 1.5f && FriendDialogue)
        {
                transform.position = new Vector3(106.73f, 43.98096f, transform.position.z);
                sp.flipX = false;
                Box.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (index2 >= lines5.Length)
                {
                    FriendDialogue = false;
                    Hacker.BossFight = true;
                    Box.SetActive(false);
                    }
                else
                    text.text = lines5[index2];
                index2 += 1;
            }
            
        }
    }
}
