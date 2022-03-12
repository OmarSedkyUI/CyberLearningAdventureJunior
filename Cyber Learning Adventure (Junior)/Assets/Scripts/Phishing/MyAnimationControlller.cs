using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimationControlller : MonoBehaviour
{
    private Animator anim;
    private Dialogue dialogue;
    private OutPutDialogue outputdialogue;
    public GameObject popup;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        dialogue = GameObject.FindObjectOfType<Dialogue>();
        outputdialogue = GameObject.FindObjectOfType<OutPutDialogue>();
    }

    private void Update()
    {
        if (dialogue.SetAnimation())
        {
            anim.SetBool("PopDownAnimation", false);
            anim.SetBool("PopUpAnimation", true);
        }
        if(!popup.activeInHierarchy)
        {
            anim.SetBool("PopUpAnimation", false);
            anim.SetBool("PopDownAnimation", true);
        }
        
    }
}
