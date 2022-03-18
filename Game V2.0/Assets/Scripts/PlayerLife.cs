using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    public HealthBar healthbar;
    private Rigidbody2D rb;
    private bool fall = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (healthbar.ReturnHealth() == 0)
        {
            Die();
            enabled = false;
        }

        if (transform.position.y < -59.03f)
        {
            Die();
            enabled = false;
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void PlayerRestartLevel()
    {
        fall = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
