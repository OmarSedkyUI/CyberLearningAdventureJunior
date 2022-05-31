using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_PopUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject popUpObject;
    [SerializeField] private Animator popUp;
    [SerializeField] private Transform player;
    bool OneTime;
    bool OnlyOne;

    private void Awake()
    {
        popUpObject.SetActive(false);
        OneTime = true;
        OnlyOne = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (OnlyOne)
            {
                popUpObject.SetActive(true);
                if (OneTime)
                {
                    popUp.Play("PopUp_Up", 0, 0.0f);
                    OneTime = false;
                }
                OnlyOne = false;
            }
        }
    }
}
