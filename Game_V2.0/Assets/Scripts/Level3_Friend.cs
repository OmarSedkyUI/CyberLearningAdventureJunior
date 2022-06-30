using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_Friend : MonoBehaviour
{
    [SerializeField] private Transform player;
    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x)
            sp.flipX = false;
        else
            sp.flipX = true;
    }
}
