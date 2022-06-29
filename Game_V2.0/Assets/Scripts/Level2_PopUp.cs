using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_PopUp : MonoBehaviour
{
    [SerializeField] private Level2_HealthBar healthBar;
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject popUp2;
    [SerializeField] private GameObject popUp3;
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressElse()
    {
        healthBar.DecHealth(10);
    }
    public void PressX()
    {
        popUp.SetActive(false);
        popUp2.SetActive(false);
        popUp3.SetActive(false);
        Player.GetComponent<Level2_PlayerMovement>().stop = false;
    }
}
