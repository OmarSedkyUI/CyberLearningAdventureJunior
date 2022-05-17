using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal_2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject Anonymos;
    [SerializeField] private GameObject ChatBot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            button.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().stop = true;
                Anonymos.SetActive(true);
                StartCoroutine(StartChatBot());
            }
        }
        else
            button.SetActive(false);
    }

    IEnumerator StartChatBot()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        ChatBot.SetActive(true);
    }
}
