using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_ElevatorController : MonoBehaviour
{
    [SerializeField] private Transform dest1;
    [SerializeField] private Transform dest2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<Level2_PlayerMovement>().moveElevator)
        {
            if(GameObject.Find("Hacker").GetComponent<Level2_Hacker_Level2>().choice == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest1.position, 8 * Time.deltaTime);
            }
            else if (GameObject.Find("Hacker").GetComponent<Level2_Hacker_Level2>().choice == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest2.position, 8 * Time.deltaTime);
            }
            
        }
    }
}
