using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform CameraPos1;
    [SerializeField] private Transform CameraPos2;
    [SerializeField] private Transform CameraPosBoss;

    // Update is called once per frame
    void Update()
    {


        if (player.position.x <= -0.02f)
        {
            transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
        }

        else if (player.position.x >= 137.5575f)
        {
            transform.position = new Vector3(137.5575f, player.position.y + 4, transform.position.z);
        }

        else if (player.position.x >= 100.34f && player.position.y >= 23f && Level1_Hacker.BossDialogue)
        {
            GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, CameraPos1.transform.position, 30 * Time.deltaTime);
        }

        else if (player.position.x >= 100.34f && player.position.y >= 23f && Level1_Friend.FriendDialogue)
        {
            transform.position = Vector3.Lerp(transform.position, CameraPos2.transform.position, 3 * Time.deltaTime);
        }
        else if (!Level1_Hacker.BossDialogue && !Level1_Friend.FriendDialogue && !Level1_Hacker.WinScene)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 4, transform.position.z), 30 * Time.deltaTime);
        }
        else if (Level1_Hacker.WinScene)
        {
            GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, CameraPosBoss.transform.position, 30 * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
            
        }
    }
}
