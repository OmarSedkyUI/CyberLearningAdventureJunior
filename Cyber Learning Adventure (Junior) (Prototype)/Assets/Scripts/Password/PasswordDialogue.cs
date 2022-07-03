using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordDialogue : MonoBehaviour
{
    [SerializeField] private UI_InputWindow inputWindow;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
    }

    public void getNextLine()
    {
        if(textComponent.text == lines[index])
        {
            nextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);

            inputWindow.Show();
        }
    }

    public void Skip()
    {
        gameObject.SetActive(false);
        inputWindow.Show();
    }
}
