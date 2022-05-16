using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform hacker;
    [SerializeField] private Transform CamDest;
    private float dirx = 0f;
    private float moveSpeed = 15f;
    public Camera cam;
    public float defaultCam;
    Rigidbody2D rb;

    private void Start()
    {
        defaultCam = GetComponent<Camera>().orthographicSize;
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
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
            GameObject.Find("Player").GetComponent<PlayerMovement>().stop = true;
            transform.position = Vector3.MoveTowards(transform.position, CamDest.position, 12 * Time.deltaTime);
            
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
        }

        if (player.position.x > 301.2252f && player.position.x < 425.9907f && GetComponent<Camera>().orthographicSize <= 11.63 && dirx > 0f)
            GetComponent<Camera>().orthographicSize += 0.002f;
        else if(player.position.x > 425.9907f && GetComponent<Camera>().orthographicSize >= defaultCam + 2 && dirx > 0f)
            GetComponent<Camera>().orthographicSize -= 0.02f;
    }
}
