using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_AppleController : MonoBehaviour
{
    public Level1_HealthBar healthbar;
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
