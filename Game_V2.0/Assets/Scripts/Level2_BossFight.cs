using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2_BossFight : MonoBehaviour
{
    [SerializeField] private GameObject FightGame;
    [SerializeField] private GameObject LevelComplete;
    [SerializeField] private GameObject Complete;
    [SerializeField] private TextMeshProUGUI link;
    [SerializeField] private string[] Links;
    [SerializeField] private string[] FakeLinks;
    public Level2_HealthBar healthbar;
    private Animator anim;

    private int index;

    private void Start()
    {
        anim = GetComponent<Animator>();
        index = 0;
        link.text = Links[index];
        anim.SetBool("FadeIn", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadNextLink()
    {
        anim.SetBool("FadeOut", true);
        anim.SetBool("FadeIn", false);
        yield return new WaitForSecondsRealtime(0.7f);
        index += 1;
        link.color = Color.white;
        link.text = Links[index];
        anim.SetBool("FadeIn", true);
        anim.SetBool("FadeOut", false);
    }

    public void PressYes()
    {
        if (CheckFakeLink(link.text).Equals("Legit"))
            link.color = Color.green;
        else
        {
            link.color = Color.red;
            healthbar.DecHealth(10);
        }
        if (index < (Links.Length - 1))
            StartCoroutine(LoadNextLink());
        else
        {
            FightGame.SetActive(false);
            LevelComplete.SetActive(true);
            Complete.SetActive(true);
        }
    }

    public void PressNo()
    {
        if (CheckFakeLink(link.text).Equals("Fake"))
            link.color = Color.green;
        else
        {
            link.color = Color.red;
            healthbar.DecHealth(10);
        }
        if (index < (Links.Length - 1))
            StartCoroutine(LoadNextLink());
        else
        {
            FightGame.SetActive(false);
            LevelComplete.SetActive(true);
            Complete.SetActive(true);
        }
    }

    private string CheckFakeLink(string li)
    {
        string Output = "Legit";
        for (int i = 0; i < FakeLinks.Length; i++)
        {
            if(li.Equals(FakeLinks[i]))
            {
                Output = "Fake";
                break;
            }
        }
        return Output;
    }
}
