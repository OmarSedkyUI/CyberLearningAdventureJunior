using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject Text;
    public void Start()
    {
        Text.SetActive(false);
    }

    private void OnMouseEnter()
    {
        Text.SetActive(true);
    }

    public void OnMouseExit()
    {
        Text.SetActive(false);
    }

}
