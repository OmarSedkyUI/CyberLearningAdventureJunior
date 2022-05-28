using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Level2_Password : MonoBehaviour
{
    static public string Pass = "";
    static private string[] namesArray;
    static string fileName;
    static string myFilePath;

    static public bool LengthCheck()
    {
        if (Pass.Length >= 8 && Pass.Length <= 64)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static public bool SpecialCheck()
    {
        string regex1 = "^(?=.*[a-z])"; //represent at least one lowercase character.
        string regex2 = "(?=.*[A-Z])"; //represents at least one uppercase character.
        string regex3 = "(?=.*\\d)"; //represents at least one numeric value.
        string regex4 = "(?=.*[-+_!@#$%^&*., ?])"; //represents at least one special character.
        Regex rgx1 = new Regex(regex1);
        Regex rgx2 = new Regex(regex2);
        Regex rgx3 = new Regex(regex3);
        Regex rgx4 = new Regex(regex4);
        Match m1 = rgx1.Match(Pass);
        Match m2 = rgx2.Match(Pass);
        Match m3 = rgx3.Match(Pass);
        Match m4 = rgx4.Match(Pass);
        if (m1.Success && m2.Success && m3.Success && m4.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static public bool CommonPassCheck()
    {
        fileName = "Scripts/1000-most-common-passwords.txt";
        myFilePath = Application.dataPath + "/" + fileName;
        namesArray = File.ReadAllLines(myFilePath);
        bool found = false;
        int i = 0;
        foreach (string passline in namesArray)
        {
            if (Pass == passline)
            {
                found = true;
                break;
            }
            i += 1;
        }
        if (!found && Pass != "")
            return true;
        else
            return false;
    }
}
