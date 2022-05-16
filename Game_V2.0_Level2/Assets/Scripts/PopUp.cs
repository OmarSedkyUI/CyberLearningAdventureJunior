using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressYes()
    {
        healthBar.DecHealth(10);
    }
    public void PressNo()
    {
        healthBar.DecHealth(10);
    }
    public void PressX()
    {
        popUp.SetActive(false);
        Player.GetComponent<PlayerMovement>().stop = false;
    }
}
