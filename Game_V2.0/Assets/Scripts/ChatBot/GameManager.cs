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



public class BotDialog : Dialog
{
    Button Next = Middle.Next;

    [Expression("Hi I am fine and you ")]

    [Expression("Great and you?")]
    public void DoubleGreetings(Context context, Result result)
    {
        result.SendResponse("I am doing great ");
        result.SendResponse("I am one of the creators of the game and our team is giving players unlimited hints to bypass next levels ");
        result.SendResponse("Just provide me with your username to link the hints with your account, and your password as well for authentication purposes");
    }


    [Expression("Hello ")]

    public void Greetings(Context context, Result result)
    {
        result.SendResponse("Sounds Good!");
        result.SendResponse("I am one of the creators of the game and our team is giving players unlimited hints to bypass next levels ");
        result.SendResponse("Just provide me with your username to link the hints with your account, and your password as well for authentication purposes");
    }

    [Expression("Yes sure ")]
    [Expression("Ok wait")]
    [Expression("Yeah !!! ")]
    public void Approval(Context context, Result result)
    {
        result.SendResponse("You are trapped , I am a hacker and now I got your credentials thanks :))))) ");

        Middle.Win = false;
        Next.gameObject.SetActive(true);
    }

    [Expression("No that's fake")]

    [Expression("No I will report you")]
    public void Denial(Context context, Result result)
    {
        result.SendResponse("Ahhh you caught me , well done !! Stay Safe Online!!!");

        Middle.Win = true;
        Next.gameObject.SetActive(true);
    }
}

public static class Middle
{
    public static bool Win = false;
    public static Button Next;
}

public class GameManager : MonoBehaviour
{
    OscovaBot MainBot;

    public GameObject chatPanel, textObject, ChatBot;
    public InputField chatBox;
    public TMPro.TMP_Dropdown mydrop;

    public Color UserColor, BotColor;

    Button Next;

    [SerializeField] private Level2_HealthBar healthBar;

    //public VictoryChecker VC;

    List<Message> Messages = new List<Message>();

    private void Awake()
    {
        Middle.Next = GameObject.Find("Next").GetComponent<Button>();
        Next = Middle.Next;
        Next.gameObject.SetActive(false);
        ChatBot = GameObject.Find("ChatBot");
        ChatBot.gameObject.SetActive(false);
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
        newMessage.TextObject.color = messageType == MessageType.User ? UserColor : BotColor;

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

    public void SendMessageToBot()
    {
        var userMessage = mydrop.options[mydrop.value].text;

        if (!string.IsNullOrEmpty(userMessage))
        {
            Debug.Log($"OscovaBot:[USER] {userMessage} ");
            AddMessage($" You: {userMessage} ", MessageType.User);
            var request = MainBot.MainUser.CreateRequest(userMessage);
            var evaluationResult = MainBot.Evaluate(request);
            evaluationResult.Invoke();

            //chatBox.Select();
            //chatBox.text = "";
        }
    }

    public void SetInputField()
    {
        chatBox.text = mydrop.options[mydrop.value].text;
    }

    public void NextHints()
    {
        List<string> hints = new List<string>();

        hints.Add("Yes sure");
        hints.Add("No that's fake");
        hints.Add("Ok wait");
        hints.Add("No I will report you");

        ClearDrop();

        AddEmptyItem();

        mydrop.AddOptions(hints);


        mydrop.onValueChanged.AddListener(delegate

        {
            ValueChanged(mydrop);
        }

        );

    }

    public void ValueChanged(TMPro.TMP_Dropdown droppp)
    {
        ClearDrop();
    }
    public void ClearDrop()
    {
        mydrop.ClearOptions();
    }
    public void AddEmptyItem()
    {
        TMP_Dropdown.OptionData newdata;

        newdata = new TMP_Dropdown.OptionData();
        newdata.text = "";
        mydrop.options.Add(newdata);
    }

    public void Ignore()
    {
        StartCoroutine(Text());

        IEnumerator Text()  //  <-  its a standalone method
        {
            yield return new WaitForSeconds(1);

            AddMessage($" Anonymous: Ah! Well done for ignoring my message ", MessageType.Bot);

            yield return new WaitForSeconds(2);

            /*VC = GameObject.FindObjectOfType(typeof(VictoryChecker)) as VictoryChecker;
            VC.Button(true);*/
            Win();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToBot();
        }
    }

    public void Press()
    {
        /*bool Win = Middle.Win;
        VictoryChecker VC = GameObject.FindObjectOfType(typeof(VictoryChecker)) as VictoryChecker;
        VC.Button(Win);*/
        if (Middle.Win)
        {
            Win();
        }
        else
        {
            healthBar.DecHealth(10);
            Next.gameObject.SetActive(false);
            RemoveMessage();
            StartCoroutine(Wait());
            StartBot();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    private void Win()
    {
        ChatBot.gameObject.SetActive(false);
    }

    public void StartBot()
    {
        StartCoroutine(Text());

        IEnumerator Text()  //  <-  its a standalone method
        {
            yield return new WaitForSeconds(2);
            AddMessage($" Anonymous: Hello my friend how are you ? ", MessageType.Bot);
        }

        try
        {
            MainBot = new OscovaBot();
            OscovaBot.Logger.LogReceived += (s, o) =>
            {
                Debug.Log($"OscovaBot: {o.Log}");
            };

            MainBot.Dialogs.Add(new BotDialog());
            //Knowledge.json file referenced without extension.
            //Workspace file extensions must be changed from .west to .json
            //var txtAsset = (TextAsset)Resources.Load("knowledge", typeof(TextAsset));
            //var tileFile = txtAsset.text;
            //MainBot.ImportWorkspace("tileFile");
            MainBot.Trainer.StartTraining();

            MainBot.MainUser.ResponseReceived += (sender, evt) =>
            {
                StartCoroutine(Text());

                IEnumerator Text()  //  <-  its a standalone method
                {
                    yield return new WaitForSeconds(2);
                    AddMessage($" Anonymous: {evt.Response.Text} ", MessageType.Bot);
                    NextHints();
                };
            };
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }
}