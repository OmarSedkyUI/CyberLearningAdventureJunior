using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_PopUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject popUpObject;
    [SerializeField] private Animator popUp;
    [SerializeField] private GameObject popUpObject2;
    [SerializeField] private Animator popUp2;
    [SerializeField] private GameObject popUpObject3;
    [SerializeField] private Animator popUp3;
    [SerializeField] private Transform player;
    bool OneTime;
    bool OnlyOne;
    private int number;

    private void Awake()
    {
        popUpObject.SetActive(false);
        popUpObject2.SetActive(false);
        popUpObject3.SetActive(false);
        OneTime = true;
        OnlyOne = true;
        number = Random.Range(1, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (OnlyOne)
            {
                number =1;
                switch(number)
                {
                    case 1:
                        popUpObject.SetActive(true);
                        if (OneTime)
                        {
                            popUp.Play("PopUp_Up", 0, 0.0f);
                            OneTime = false;
                        }
                        OnlyOne = false;
                        break;

                    case 2:
                        popUpObject2.SetActive(true);
                        if (OneTime)
                        {
                            popUp2.Play("PopUp_Up", 0, 0.0f);
                            OneTime = false;
                        }
                        OnlyOne = false;
                        break;

                    case 3:
                        popUpObject3.SetActive(true);
                        if (OneTime)
                        {
                            popUp3.Play("PopUp_Up", 0, 0.0f);
                            OneTime = false;
                        }
                        OnlyOne = false;
                        break;

                }
            }
        }
    }
}
