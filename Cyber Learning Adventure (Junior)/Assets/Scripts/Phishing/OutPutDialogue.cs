using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OutPutDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string line1;
    public string line2;
    public string line3;
    public float textSpeed;
    private int index;
    public GameObject popup;
    public Button button1;
    public Button button2;
    public Button button3;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
    }
    private void Update()
    {
        if (textComponent.text == line1 || textComponent.text == line2 || textComponent.text == line3)
        {
            StopAllCoroutines();
        }
    }
    public void PressYes()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        button2.interactable = false;
        button3.interactable = false;
        index = 1;
        StartCoroutine(TypeLine(line1));
        
    }

    public void PressNo()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        button1.interactable = false;
        button3.interactable = false;
        index = 2;
        StartCoroutine(TypeLine(line2));
    }

    public void X()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;

        index = 3;
        StartCoroutine(TypeLine(line3));
    }

    IEnumerator TypeLine(string line)
    {
        foreach (char c in line)
        {
            Debug.Log(c);
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void next()
    {

        if(index == 1)
        {
            if (textComponent.text != line1)
            {
                textComponent.text = line1;
            }
            else
            {
                gameObject.SetActive(false);
                button2.interactable = true;
                button3.interactable = true;
            }        
        }
        else if(index == 2)
        {
            if (textComponent.text != line2)
            {
                textComponent.text = line2;
            }
            else
            {
                gameObject.SetActive(false);
                button1.interactable = true;
                button3.interactable = true;
            }
        }
        else
        {
            if (textComponent.text != line3)
            {
                textComponent.text = line3;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        
    }
}
