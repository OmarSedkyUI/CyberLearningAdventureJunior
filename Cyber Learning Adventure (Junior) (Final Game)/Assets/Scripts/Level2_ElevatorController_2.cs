using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_ElevatorController_2 : MonoBehaviour
{
    [SerializeField] private Transform dest;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Hacker").GetComponent<Level2_Hacker_Level2>().choice == 1)
            transform.position = new Vector3(transform.position.x, dest.position.y, transform.position.z);
        else if(GameObject.Find("Hacker").GetComponent<Level2_Hacker_Level2>().choice == 2)
        {
            if (GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().moveElevator_2)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest.position, 8 * Time.deltaTime);
            }
        }
    }
}
