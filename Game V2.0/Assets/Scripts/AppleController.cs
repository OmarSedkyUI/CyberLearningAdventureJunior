using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    public HealthBar healthbar;
    [SerializeField] private AudioSource CollectApple;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthbar.IncHealth(10);
            gameObject.SetActive(false);
        }
    }
}
