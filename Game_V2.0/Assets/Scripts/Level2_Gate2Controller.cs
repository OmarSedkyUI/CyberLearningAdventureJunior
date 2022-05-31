using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Gate2Controller : MonoBehaviour
{
    
    private Animator anim;
    public Level2_Terminal_2 it;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (it.OpenGate())
        {
            anim.SetBool("Openning", true);
        }

        if(player.position.x > 295)
        {
            anim.SetBool("Openning", false);
        }
    }
}
