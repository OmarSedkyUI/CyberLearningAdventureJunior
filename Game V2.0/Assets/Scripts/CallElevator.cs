using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevator: MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject button;
    public int lvl;

    private void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2f)
        {
            button.SetActive(true);
        }
        if (ElevatorController.level == lvl)
        {
            button.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 1.5f)
        {
            ElevatorController.level = lvl;
        }
    }
}
