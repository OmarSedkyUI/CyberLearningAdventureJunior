using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    [SerializeField] private GameObject Dialogue;
    private SpriteRenderer sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hacker"))
        {
            Dialogue.SetActive(true);
         
            StartCoroutine(DisableDialogue());
        }
    }

    IEnumerator DisableDialogue()
    {
        yield return new WaitForSeconds(5);
        Dialogue.SetActive(false);
    }
}
