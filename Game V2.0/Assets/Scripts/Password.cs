using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour
{
    //static string line;
    public static bool Password1(string Password)
    {
        if (Password.Length >= 8 && Password.Length <= 64)
        {
            Debug.Log("Well done!, since your password is of size between 8 and 64 characters, you made it hard for me to guess your password");
            return true;
        }
        else
        {
            if (Password.Length < 8)
            {
                Debug.Log("Password is too short, You made it easy for me to guess your password using bruteforce.");
            }
            else
            {
                Debug.Log("Maximum password size is 64 characters.");
            }
            return false;
        }
    }

    public static bool Password2()
    {
        return false;
    }
}
