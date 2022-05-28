using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1_Terminal3 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Square;
    [SerializeField] private Transform player;
    [SerializeField] public GameObject CongratsBox;
    [SerializeField] public GameObject ImprovePassBox;
    [SerializeField] public TMP_InputField input;
    [SerializeField] public TextMeshProUGUI Error;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public TextMeshProUGUI pass;
    [SerializeField] public GameObject Apple;
    [SerializeField] private GameObject button;
    private bool done;
    private bool oneApple;
    [SerializeField] private string[] lines;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        Square.color = Color.red;
        index = 0;
        done = false;
        oneApple = true; 
    }

    // Update is called once per frame
    void Update()
    {
        pass.text = Level1_Passwords.Pass;
        if (Level1_Passwords.CommonPassCheck())
        {
            Square.color = Color.green;
        }
        else
        {
            Square.color = Color.red;
            done = false;
        }

        if (Vector2.Distance(player.position, transform.position) < 2f && !CongratsBox.activeSelf && !ImprovePassBox.activeSelf && !done)
        {
            button.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) < 2f && !done)
        {
            
            button.SetActive(false);
            if (Square.color == Color.green)
            {
                if (index >= lines.Length)
                {
                    CongratsBox.SetActive(false);
                    text.text = "Well Done!";
                    done = true;
                    GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = true;
                }
                else
                {
                    CongratsBox.SetActive(true);
                    GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = false;
                    text.text = lines[index];
                    if (oneApple)
                    {
                        StartCoroutine(ShowApple());
                        oneApple = false;
                    }
                }
                index += 1;
            }
            else
            {
                ImprovePassBox.SetActive(true);
                Error.enabled = false;
                GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = false;
            }
        }
        else if (Vector2.Distance(player.position, transform.position) > 2f && Vector2.Distance(player.position, transform.position) < 2.5f)
        {
            GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = true;
            ImprovePassBox.SetActive(false);
            CongratsBox.SetActive(false);
            button.SetActive(false);
        }

        if (ImprovePassBox.activeSelf && Input.GetKeyDown(KeyCode.Return) && Vector2.Distance(player.position, transform.position) < 2f)
        {
            Level1_Passwords.Pass = input.text;
            if (Level1_Passwords.CommonPassCheck())
            {
                ImprovePassBox.SetActive(false);
                Error.enabled = false;
                GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().enabled = true;
                CongratsBox.SetActive(true);
                index += 1;
                if (oneApple)
                {
                    StartCoroutine(ShowApple());
                    oneApple = false;
                }
            }
            else
            {
                Error.text = "Your password is commonly used.";
                Error.enabled = true;
            }

        }
    }

    IEnumerator ShowApple()
    {
        yield return new WaitForSeconds(1);
        Apple.SetActive(true);
    }
}
