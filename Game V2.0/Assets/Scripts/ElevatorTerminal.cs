using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTerminal : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    private bool inColl = false;
    static public int lvl;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inColl)
        {
            Box.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inColl = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Box.SetActive(false);
        inColl = false;
    }

    public void PressButton(int level)
    {
        lvl = level;
        Box.SetActive(false);
    }
}
