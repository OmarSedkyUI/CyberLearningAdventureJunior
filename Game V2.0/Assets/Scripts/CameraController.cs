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

        if(player.position.x <= -0.02f)
        {
            transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
        }

        if(player.position.x >= 164.77f)
        {
            transform.position = new Vector3(164.77f, player.position.y + 4, transform.position.z);
        }
    }
}
