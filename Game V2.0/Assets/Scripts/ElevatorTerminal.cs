using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorTerminal : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    private bool inColl = false;
    static public int lvl;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inColl)
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
                Button2.enabled = false;
                Button3.enabled = false;
                Button4.enabled = false;
                break;
            case 2:
                Button3.enabled = false;
                Button4.enabled = false;
                break;
            case 3:
                Button4.enabled = false;
                break;
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
