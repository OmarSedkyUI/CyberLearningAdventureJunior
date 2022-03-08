using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;

public class PasswordChecker : MonoBehaviour
{
    public UserInfo userInfo;
    [SerializeField] private UI_InputWindow inputWindow;
    [SerializeField] private ShowOutput showOutput;
    private string Password;
    public TMP_InputField inputField;
    public TextMeshProUGUI outputField;
    public string line;
    public float textSpeed;
    bool Correct = false;
    bool Done = false;
    bool Clicked = false;

    public VictoryChecker VC;

    public void Checker()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        string Name = userInfo.userName;

        Password = inputField.text;

        string[] namesArray;

        string fileName = "1000-most-common-passwords.txt";
        string myFilePath = Application.dataPath + "/Scripts/Password Conditions" + "/" + fileName;

        /*string[] lines = System.IO.File.ReadAllLines(@"D:\Game Development\Cyber Learning Adventure (Junior)\Assets\Scripts\Password Conditions\CommonPasswords.txt");
        string[] Seqlines = System.IO.File.ReadAllLines(@"D:\Game Development\Cyber Learning Adventure (Junior)\Assets\Scripts\Password Conditions\SequentialPass.txt");
        string[] SpecialChars = System.IO.File.ReadAllLines(@"D:\Game Development\Cyber Learning Adventure (Junior)\Assets\Scripts\Password Conditions\SpecialChars.txt");*/

        showOutput.Show();
        inputWindow.Hide();

        if (string.Equals(sceneName, "Password1")) //Minimum 8 Characters And Maximum 64 Characters Condition
        {
            if (Password.Length >= 8 && Password.Length <= 64)
            {
                line = "Well done!, since your password is of size between 8 and 64 characters, you made it hard for me to guess your password";
                Correct = true;
            }
            else
            {
                if (Password.Length < 8)
                {
                    line = "Password is too short, You made it easy for me to guess your password using bruteforce.";
                }
                else
                {
                    line = "Maximum password size is 64 characters.";
                }
            }
        }
        else if (string.Equals(sceneName, "Password2")) //Common Passwords Check
        {
            if (Password.Length >= 8 && Password.Length <= 64)
            {
                //Level 2:
                bool flag = false;
                Password = inputField.text;
                namesArray = File.ReadAllLines(myFilePath);
                foreach (string passline in namesArray)
                {
                    if (Password == passline)
                    {
                        flag = true;
                        break;

                    }
                }
                if (flag)
                {
                    line = "Password already in list try agian and found in the list.";
                }
                else
                {
                    line = "Well done, your password is unique thus made even harder for me to guess your password";
                    Correct = true;
                }
            }
            else
            {
                if (Password.Length < 8)
                    line = "Password is too short, You made it easy for me to guess your password using bruteforce.";
                else
                    line = "Maximum password size is 64 characters.";
            }
        }
        else if (string.Equals(sceneName, "Password3"))  //Contains UpperCase & LowerCase Letter With Numbers & Special Characters
        {
            if (Password.Length >= 8 && Password.Length <= 64)
            {
                //Level 2:
                bool flag = false;
                Password = inputField.text;
                namesArray = File.ReadAllLines(myFilePath);
                foreach (string passline in namesArray)
                {
                    if (Password == passline)
                    {
                        flag = true;
                        break;

                    }
                }
                if (flag)
                {
                    line = "Password already in list try agian and found in the list.";
                }
                else
                {
                    //Level 3: 
                    string regex1 = "^(?=.*[a-z])"; //represent at least one lowercase character.
                    string regex2 = "(?=.*[A-Z])"; //represents at least one uppercase character.
                    string regex3 = "(?=.*\\d)"; //represents at least one numeric value.
                    string regex4 = "(?=.*[-+_!@#$%^&*., ?])"; //represents at least one special character.
                    Regex rgx1 = new Regex(regex1);
                    Regex rgx2 = new Regex(regex2);
                    Regex rgx3 = new Regex(regex3);
                    Regex rgx4 = new Regex(regex4);
                    Match m1 = rgx1.Match(Password);
                    Match m2 = rgx2.Match(Password);
                    Match m3 = rgx3.Match(Password);
                    Match m4 = rgx4.Match(Password);
                    if (m1.Success && m2.Success && m3.Success && m4.Success)
                    {
                        line = "Your password now includes special character/uppercase/lowercase/numeric value, You are starting to get the hang of it.";
                        Correct = true;
                    }
                    else if (!m1.Success)
                    {
                        line = "You have to include at least one lowercase character in your password to make it a strong one, give it another try.";
                    }
                    else if (!m2.Success)
                    {
                        line = "You have to include at least one uppercase character in your password to make it a strong one, give it another try.";
                    }
                    else if (!m3.Success)
                    {
                        line = "You have to include at least one numeric value in your password to make it a strong one, give it another try.";
                    }
                    else if (!m4.Success)
                    {
                        line = "You have to include at least one special character in your password to make it a strong one, give it another try.";
                    }
                }

            }
            else
            {
                if (Password.Length < 8)
                    line = "Password is too short, You made it easy for me to guess your password using bruteforce.";
                else
                    line = "Maximum password size is 64 characters.";
            }
        }
        else if (string.Equals(sceneName, "Password4"))  //Contains Sequential & Repeated Characters
        {
            if (Password.Length >= 8 && Password.Length <= 64)
            {
                //Level 2:
                bool flag = false;
                Password = inputField.text;
                namesArray = File.ReadAllLines(myFilePath);
                foreach (string passline in namesArray)
                {
                    if (Password == passline)
                    {
                        flag = true;
                        break;

                    }
                }
                if (flag)
                {
                    line = "Password already in list try agian and found in the list.";
                }
                else
                {
                    //Level 3:
                    string regex1 = "^(?=.*[a-z])"; //represent at least one lowercase character.
                    string regex2 = "(?=.*[A-Z])"; //represents at least one uppercase character.
                    string regex3 = "(?=.*\\d)"; //represents at least one numeric value.
                    string regex4 = "(?=.*[-+_!@#$%^&*., ?])"; //represents at least one special character.
                    Regex rgx1 = new Regex(regex1);
                    Regex rgx2 = new Regex(regex2);
                    Regex rgx3 = new Regex(regex3);
                    Regex rgx4 = new Regex(regex4);
                    Match m1 = rgx1.Match(Password);
                    Match m2 = rgx2.Match(Password);
                    Match m3 = rgx3.Match(Password);
                    Match m4 = rgx4.Match(Password);
                    if (m1.Success && m2.Success && m3.Success && m4.Success)
                    {
                        //Level 4:
                        bool repeatedletters = false;
                        int count = 1;
                        for (int i = 0; i < Password.Length - 1; i++)
                        {
                            if (count >= 3)
                            {
                                repeatedletters = true;
                                break;
                            }

                            if (Password[i] == Password[i + 1])
                            {
                                count += 1;

                            }
                            else
                            {
                                count = 1;
                            }
                        }
                        if (repeatedletters)
                        {
                            line = "You cannot include repeated letters more than 3 times in your password.";
                        }
                        else
                        {
                            line = "Great Job!, now that you have learned all the essenitals to making a password you can secure your account by making a strong password";
                            Correct = true;
                        }
                    }
                    else if (!m1.Success)
                    {
                        line = "You have to include at least one lowercase character in your password to make it a strong one, give it another try.";
                    }
                    else if (!m2.Success)
                    {
                        line = "You have to include at least one uppercase character in your password to make it a strong one, give it another try.";
                    }
                    else if (!m3.Success)
                    {
                        line = "You have to include at least one numeric value in your password to make it a strong one, give it another try.";
                    }
                    else if (!m4.Success)
                    {
                        line = "You have to include at least one special character in your password to make it a strong one, give it another try.";
                    }
                }

            }
            else
            {
                if (Password.Length < 8)
                    line = "Password is too short, You made it easy for me to guess your password using bruteforce.";
                else
                    line = "Maximum password size is 64 characters.";
            }
        }

        StartCoroutine(TypeLine(line));

       /*else if (string.Equals(sceneName, "Password5")) //Contains player's name or game name
         {
             if (!Password.Contains(Name) || !Password.Contains("cyberlearningadventure"))
                Correct = true;
         }
         else if (string.Equals(sceneName, "Password6")) //Contains Sequential characters
         {
             bool isSequential = false;
            for (int i = 0; i < Seqlines.Length; i++)
            {
                if (Password.Contains(Seqlines[i]))
                    isSequential = true;
            }
            if (!isSequential)
            {
                Correct = true;
            }
         }*/

        /*
        showOutput.Show();

        inputWindow.Hide();

        if (Correct)
        {
            StartCoroutine(TypeLine(0));
            //victoryChecker.Button(true);
        }
        else
        {
            if (string.Equals(sceneName, "Password1")) //Minimum 8 Characters And Maximum 64 Characters Condition
            {
                if (Password.Length < 8)
                {
                    StartCoroutine(TypeLine(1));
                }
                else
                {
                    StartCoroutine(TypeLine(2));
                }
            }
            else
            {
                StartCoroutine(TypeLine(1));
            }
            //victoryChecker.Button(false);
        }
        */
    }
    IEnumerator TypeLine(string lines)
    {
        foreach (char c in lines.ToCharArray())
        {
            outputField.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        Done = true;

        yield return new WaitUntil(() => Clicked == true);

        while (Done)
        {
            //VictoryChecker VC = gameObject.GetComponent<VictoryChecker>();
            VC = GameObject.FindObjectOfType(typeof(VictoryChecker)) as VictoryChecker;
            VC.Button(Correct);
            Done = false;
        }
    }

    public void Click()
    {
        if(Done)
            Clicked = true;
    }
}
