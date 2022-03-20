using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform hacker;
    [SerializeField] private Transform friend;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);

        if(player.position.x <= -0.02f)
        {
            transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
        }

        if(player.position.x >= 164.77f)
        {
            transform.position = new Vector3(164.77f, player.position.y + 4, transform.position.z);
        }

        if(player.position.x >= 100.34f && player.position.y >= 23f && Hacker.BossDialogue)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            transform.transform.localPosition = Vector3.MoveTowards(transform.transform.localPosition, new Vector3(141.02f, hacker.transform.localPosition.y, transform.transform.localPosition.z), 30);
        }
    }
}
