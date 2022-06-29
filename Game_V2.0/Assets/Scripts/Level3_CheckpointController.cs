using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_CheckpointController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("start", true);
            StartCoroutine(ResetAnimation());
        }
    }

    IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("start", false);
    }
}
