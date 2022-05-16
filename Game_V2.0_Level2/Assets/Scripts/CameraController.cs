using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= -0.02f)
        {
            transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
        }
        else if(player.position.x >= 155f)
        {
            transform.position = new Vector3(155f, player.position.y + 4, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
        }
    }
}
