using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform CameraPos1;
    [SerializeField] private Transform CameraPos2;
    [SerializeField] private Transform CameraPosBoss;
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
            GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().stop = true;
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

            else if (player.position.x >= 100.34f && player.position.y >= 23f && Level1_Hacker.BossDialogue)
            {
                GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, CameraPos1.transform.position, 30 * Time.deltaTime);
            }

            else if (player.position.x >= 100.34f && player.position.y >= 23f && Level1_Friend.FriendDialogue)
            {
                transform.position = Vector3.Lerp(transform.position, CameraPos2.transform.position, 3 * Time.deltaTime);
            }
            else if (!Level1_Hacker.BossDialogue && !Level1_Friend.FriendDialogue && !Level1_Hacker.WinScene)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 4, transform.position.z), 30 * Time.deltaTime);
            }
            else if (Level1_Hacker.WinScene)
            {
                GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, CameraPosBoss.transform.position, 30 * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(player.position.x, player.position.y + 4, transform.position.z);
            }
        }
    }

    public void PressPlay()
    {

        anim.Play("Level1_CameraAnimation", 0);
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        MainMenu.SetActive(false);
        UI.SetActive(true);
        StartCoroutine(Wait(info));
    }

    IEnumerator Wait(AnimatorStateInfo info)
    {
        yield return new WaitForSeconds(info.length);
        GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().stop = false;
        anim.enabled = false;
    }
}
