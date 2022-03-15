using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
        if(player.position.x <= -1.122482f)
        {
            transform.position = new Vector3(-1.122482f, player.position.y + 4, transform.position.z);
        }
    }
}
