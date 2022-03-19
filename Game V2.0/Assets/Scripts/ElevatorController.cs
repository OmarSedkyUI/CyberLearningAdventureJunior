using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] private Transform player;
    [SerializeField] private Transform level1;
    [SerializeField] private Transform level2;
    [SerializeField] private Transform level3;
    [SerializeField] private Transform level4;
    public float speed;
    public static int level;


    private void Update()
    {
        switch (level)
        {
            case 1:
                transform.position = Vector2.MoveTowards(transform.position, level1.position, speed * Time.deltaTime);
                break;
            case 2:
                transform.position = Vector2.MoveTowards(transform.position, level2.position, speed * Time.deltaTime);
                break;
            case 3:
                transform.position = Vector2.MoveTowards(transform.position, level3.position, speed * Time.deltaTime);
                break;
            case 4:
                transform.position = Vector2.MoveTowards(transform.position, level4.position, speed * Time.deltaTime);
                break;
        } 
    }

    public void ButtonPress(int lvl)
    {
        level = lvl;
        Box.SetActive(false);
    }
}
