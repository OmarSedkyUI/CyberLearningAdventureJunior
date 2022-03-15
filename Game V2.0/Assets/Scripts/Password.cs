using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Password : MonoBehaviour
{
    public static int Level = 1;
    public static bool LevelPassed = false;
    //static string line;
    public static int PasswordChecker(string Password)
    {
        if(Password4(Password))
        {
            Level += 4;
        }
        else if (Password3(Password))
        {
            Level += 3;
        }
        else if (Password2(Password))
        {
            Level += 2;
        }
        else if (Password1(Password))
        {
            Level += 1;
        }
        else
        {
            Level = 1;
        }
        LevelPassed = true;
        return Level;
    }

    public static bool Password1(string Password)
    {
        if (Password.Length >= 8 && Password.Length <= 64)
        {
            Debug.Log("Well done!, since your password is of size between 8 and 64 characters, you made it hard for me to guess your password.");
            return true;
        }
        else
        {
            if (Password.Length < 8)
                Debug.Log("Password is too short, You made it easy for me to guess your password using bruteforce.");
            else
                Debug.Log("Maximum password size is 64 characters.");
        }
        return false;
    }

    public static bool Password2(string Password)
    {
        string fileName = "1000-most-common-passwords.txt";
        string myFilePath = Application.dataPath + "/" + fileName;
        if (Password1(Password))
        {
            bool flag = false;
            string[] namesArray = File.ReadAllLines(myFilePath);
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
                Debug.Log("Password already in list try agian and found in the list.");
            }
            else
            {
                Debug.Log("Well done, your password is unique thus made even harder for me to guess your password.");
                return true;
            }
        }
        else
        {
            Debug.Log("Password2 is hard.");
        }
        return false;
    }

    public static bool Password3(string Password)
    {
        if (Password2(Password))
        {
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
                Debug.Log("Your password now includes special character/uppercase/lowercase/numeric value, You are starting to get the hang of it.");
                return true;
            }
            else if (!m1.Success)
            {
                Debug.Log("You have to include at least one lowercase character in your password to make it a strong one, give it another try.");
            }
            else if (!m2.Success)
            {
                Debug.Log("You have to include at least one uppercase character in your password to make it a strong one, give it another try.");
            }
            else if (!m3.Success)
            {
                Debug.Log("You have to include at least one numeric value in your password to make it a strong one, give it another try.");
            }
            else if (!m4.Success)
            {
                Debug.Log("You have to include at least one special character in your password to make it a strong one, give it another try.");
            }
        }
        else
        {
            Debug.Log("Password3 is hard.");
        }
        return false;
    }
    public static bool Password4(string Password)
    {
        if (Password3(Password))
        {
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
                Debug.Log("You cannot include repeated letters more than 3 times in your password.");
            }
            else
            {
                Debug.Log("Great Job!, now that you have learned all the essenitals to making a password you can secure your account by making a strong password.");
                return true;
            }
        }
        else
        {
            Debug.Log("Password4 is hard.");
        }
        return false;
    }
}
