using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractableTerminal.LevelPassed)
        {
            anim.SetBool("Opening", true);
        }

        if(player.position.x > 46.77077)
        {
            anim.SetBool("Opening", false);
        }
    }
}
