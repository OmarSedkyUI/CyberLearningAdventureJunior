using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform CameraPos1;
    [SerializeField] private Transform CameraPos2;

    // Update is called once per frame
    void Update()
    {
        

        if(player.position.x <= -0.02f)
        {
            transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
        }

        else if(player.position.x >= 164.77f)
        {
            transform.position = new Vector3(164.77f, player.position.y + 4, transform.position.z);
        }

        else if(player.position.x >= 100.34f && player.position.y >= 23f && Hacker.BossDialogue)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, CameraPos1.transform.position, 30 * Time.deltaTime);
        }

        else if (player.position.x >= 100.34f && player.position.y >= 23f && Friend.FriendDialogue)
        {
            transform.position = Vector3.Lerp(transform.position, CameraPos2.transform.position, 3 * Time.deltaTime);
        }
        else if(!Hacker.BossDialogue && !Friend.FriendDialogue)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 4, transform.position.z), 30 * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
            
        }
    }
}
