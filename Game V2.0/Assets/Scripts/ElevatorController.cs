using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private Animator anim;
    private int level;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        level = ElevatorTerminal.lvl;
        anim.SetInteger("Level", level);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetInteger("Level", 0);
        //anim.SetBool("Default", true);
    }
}
