using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaskManager : MonoBehaviour
{
    [SerializeField] private Button Item;
    [SerializeField] private GameObject Mask;

    // Update is called once per frame
    void Update()
    {
        if(Item.interactable)
        {
            Mask.SetActive(false);
        }
    }
}
