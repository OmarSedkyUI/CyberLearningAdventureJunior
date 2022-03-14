using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private SpriteRenderer hacker;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        hacker = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < 27.81)
        {
            hacker.flipX = true;
        }
        else
        {
            hacker.flipX = false;
        }
    }
}
