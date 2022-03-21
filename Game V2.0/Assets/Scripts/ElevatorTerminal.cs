using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorTerminal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Square1;
    [SerializeField] private SpriteRenderer Square2;
    [SerializeField] private SpriteRenderer Square3;
    [SerializeField] private GameObject Box;
    [SerializeField] private GameObject button;
    [SerializeField] private Transform player;
    static public int lvl;
    public Button BossButton;
    public Sprite DisabledBtnSprite;
    public Sprite EnabledBtnSprite;

    void Start()
    {
        BossButton.enabled = false;
        BossButton.image.sprite = DisabledBtnSprite;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2f && !Box.activeSelf)
        {
            button.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 2)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            Box.SetActive(true);
            button.SetActive(false);
        }
        else if (Vector2.Distance(player.position, transform.position) > 2f && Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Box.SetActive(false);
            button.SetActive(false);
        }
        if (Square1.color == Color.green && Square2.color == Color.green && Square3.color == Color.green)
        {
            BossButton.enabled = true;
            BossButton.image.sprite = EnabledBtnSprite;
        }
    }
}
