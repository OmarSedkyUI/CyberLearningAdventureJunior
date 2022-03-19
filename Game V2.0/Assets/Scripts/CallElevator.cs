using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevator: MonoBehaviour
{
    [SerializeField] private Transform player;
    public int lvl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 1.5f)
        {
            ElevatorController.level = lvl;
        }
    }
}
