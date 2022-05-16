using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject popUpObject;
    [SerializeField] private Animator popUp;
    [SerializeField] private Transform player;
    bool OneTime;

    private void Awake()
    {
        popUpObject.SetActive(false);
        OneTime = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().stop = true;

            popUpObject.SetActive(true);
            if (OneTime)
            {
                popUp.Play("PopUp_Up", 0, 0.0f);
                OneTime = false;
            }
        }
    }
}
