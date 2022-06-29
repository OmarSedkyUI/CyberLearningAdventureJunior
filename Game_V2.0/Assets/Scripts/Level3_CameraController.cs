using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject UI;

    Animator anim;

    private void Start()
    {
        UI.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenu.activeSelf)
        {
            transform.position = new Vector3(-9.8f, player.position.y + 4, transform.position.z);
            GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = true;
        }
        else
        {
            if (player.position.x < 0f)
            {
                transform.position = new Vector3(-0.02f, player.position.y + 4, transform.position.z);
            }
            
            else if (player.position.x >= 137.5575f)
            {
                transform.position = new Vector3(137.5575f, player.position.y + 4, transform.position.z);
            }

            else
            {
                transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
            }
        }
    }

    public void PressPlay()
    {

        anim.Play("Level3_CameraAnimation", 0);
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        MainMenu.SetActive(false);
        UI.SetActive(true);
        StartCoroutine(Wait(info));
    }

    IEnumerator Wait(AnimatorStateInfo info)
    {
        yield return new WaitForSeconds(info.length);
        GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
        anim.enabled = false;
    }
}
