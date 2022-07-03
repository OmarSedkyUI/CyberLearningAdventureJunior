using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{

    public int ItemID;
    [SerializeField] public Text XpTxt;
    [SerializeField] public Text QuantityTxt;
    [SerializeField] public GameObject ShopManager;

    void Update()
    {
        XpTxt.text = "XP: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
    }
}
