using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_PlayerLife : MonoBehaviour
{
    private Animator anim;
    public Level1_HealthBar healthbar;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (healthbar.ReturnHealth() == 0)
        {
            Level1_Passwords.Pass = "";
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
