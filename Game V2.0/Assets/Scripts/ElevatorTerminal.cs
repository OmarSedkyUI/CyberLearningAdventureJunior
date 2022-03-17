using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorTerminal : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] private Transform player;
    static public int lvl;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 1.5f)
        {
            ButtonController();
            Box.SetActive(true);
        }
    }

    private void ButtonController()
    {
        int Levels = Password.Level;
        switch (Levels)
        {
            case 1:
                Button2.enabled = true;
                Button3.enabled = true;
                Button4.enabled = true;
                break;
            case 2:
                Button3.enabled = true;
                Button4.enabled = true;
                break;
            case 3:
                Button4.enabled = true;
                break;
        }
    }
}
