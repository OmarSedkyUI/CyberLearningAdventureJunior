using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Message
{
    public string Text;
    public TextMeshProUGUI TextObject;
    public MessageType MessageType;
}

public enum MessageType
{
    User, Bot
}

public class GameManager :  MonoBehaviour
{
    public GameObject chatPanel, textObject, ChatBot, HackerTracker;
    
    public GameObject Choice1;
    public GameObject Choice2;

    int choice;

    public Color UserColor, BotColor;

    [SerializeField] private Level3_HealthBar healthBar;

    List<Message> Messages = new List<Message>();

    private void Awake()
    {
        ChatBot = GameObject.Find("ChatBot");
        ChatBot.SetActive(false);
        HackerTracker.gameObject.SetActive(false);
    }

    void Update()
    {
        switch (choice)
        {
            case 1: 
                Choice1.SetActive(true);
                break;
            case 2: 
                Choice1.SetActive(false);
                Choice2.SetActive(true);
                break;
            default: 
                break;
        }
        if(ChatBot.activeSelf)
        {
            GameObject.Find("Scroll View").GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
        }
    }

    public void AddMessage(string messageText, MessageType messageType)
    {
        if (Messages.Count >= 25)
        {
            //Remove when too much.
            Destroy(Messages[0].TextObject.gameObject);
            Messages.Remove(Messages[0]);
        }

        var newMessage = new Message { Text = messageText };

        var newText = Instantiate(textObject, chatPanel.transform);

        newMessage.TextObject = newText.GetComponent<TextMeshProUGUI>();
        newMessage.TextObject.text = messageText;
        newMessage.TextObject.color = messageType == MessageType.User ? UserColor :  BotColor;

        Messages.Add(newMessage);
    }

    public void RemoveMessage()
    {
        for (int i = (Messages.Count - 1); i >= 0; i--)
        {
            Destroy(Messages[i].TextObject.gameObject);
            Messages.Remove(Messages[i]);
        }
    }

    public void StartBot()
    {
        StartCoroutine(Text());

        IEnumerator Text()  //  <-  its a standalone method
        {
            AddMessage($"Anonymous: I found an app that can track down hacker.", MessageType.Bot);
            AddMessage("", MessageType.Bot);
            yield return new WaitForSeconds(1.5f);
            AddMessage($"Anonymous: I need to login with your account.", MessageType.Bot);
            yield return new WaitForSeconds(1.5f);
            choice = 1;
        }
    }

    public void Press(int Num)
    {
        int SwitchChoice = int.Parse(choice.ToString() + Num.ToString());
        switch (SwitchChoice)
        {
            case 11: 
                StartCoroutine(C1Reject());
                break;
            case 12: 
                StartCoroutine(C1Skeptical());
                break;
            case 21: 
                StartCoroutine(C2Reject());
                break;
            case 22:
                StartCoroutine(C2Skeptical());
                break;
            default: 
                break;
        }
    }
    public void Accept()
    {
        HackerTracker.SetActive(true);
    }
    IEnumerator C1Reject()
    {
        Choice1.transform.GetChild(1).GetComponent<Button>().enabled = false;
        Choice1.transform.GetChild(2).GetComponent<Button>().enabled = false;
        AddMessage($"You: I do not normally give my account info to strangers.", MessageType.User);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"Anonymous: If you want to beat the hacker you need to trust me.", MessageType.Bot);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"Anonymous: Help me help you.", MessageType.Bot);
        choice = 2;
    }
    IEnumerator C1Skeptical()
    {
        Choice1.transform.GetChild(1).GetComponent<Button>().enabled = false;
        Choice1.transform.GetChild(2).GetComponent<Button>().enabled = false;
        AddMessage($"You: Why do you need my account ?", MessageType.User);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"Anonymous: Because the hacker hacked my account and locked me out of it.", MessageType.Bot);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"Anonymous: You need to trust me.", MessageType.Bot);
        choice = 2;
    }

    IEnumerator C2Reject()
    {
        Choice2.transform.GetChild(1).GetComponent<Button>().enabled = false;
        Choice2.transform.GetChild(2).GetComponent<Button>().enabled = false;
        AddMessage($"You: There must be another way to beat the hacker.", MessageType.User);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"You: I will never share my account info with you.", MessageType.User);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"Anonymous: Okay then, goodluck defeating the hacker alone.", MessageType.Bot);
        yield return new WaitForSeconds(2.5f);
        ChatBot.SetActive(false);
        GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
        yield return new WaitForSeconds(1f);
        GameObject.Find("Anonymous").GetComponent<Level3_Anonymous>().run2 = true;
    }

    IEnumerator C2Skeptical()
    {
        Choice2.transform.GetChild(1).GetComponent<Button>().enabled = false;
        Choice2.transform.GetChild(2).GetComponent<Button>().enabled = false;
        AddMessage($"You: Why don't you make another account ?", MessageType.User);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"Anonymous: I can not right now.", MessageType.Bot);
        yield return new WaitForSeconds(1.5f);
        AddMessage($"You: You sound sussy.", MessageType.User);
        yield return new WaitForSeconds(0.5f);
        AddMessage($"You: I do not trust you.", MessageType.User);
        yield return new WaitForSeconds(2.5f);
        ChatBot.SetActive(false);   
        GameObject.Find("Player").GetComponent<Level3_PlayerMovement>().stop = false;
        yield return new WaitForSeconds(1f);
        GameObject.Find("Anonymous").GetComponent<Level3_Anonymous>().run2 = true;
    }
}