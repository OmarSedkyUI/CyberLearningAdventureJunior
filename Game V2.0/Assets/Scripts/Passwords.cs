using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Passwords : MonoBehaviour
{
    static public string Pass = "";
    //private int PassStrength = 0;

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

    static public bool RepetitionCheck()
    {
        bool repeatedletters = false;
        int count = 1;
        for (int i = 0; i < Pass.Length - 1; i++)
        {
            if (count >= 3)
            {
                repeatedletters = true;
                break;
            }

            if (Pass[i] == Pass[i + 1])
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
            return false;
        }
        else
        {
            return true;
        }
    }
}
   

