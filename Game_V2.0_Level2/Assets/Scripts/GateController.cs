using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    
    private Animator anim;
    public InteractableTerminal it;
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

        if(player.position.x > 183.6346)
        {
            anim.SetBool("Openning", false);
        }
    }
}
