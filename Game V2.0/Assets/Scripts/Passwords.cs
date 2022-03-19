using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class Passwords : MonoBehaviour
{
    static public string Pass = "";
    static public bool flag1 = false, flag2 = false, flag3 = false;
    [SerializeField] private SpriteRenderer Square1;
    [SerializeField] private SpriteRenderer Square2;
    [SerializeField] private SpriteRenderer Square3;
    [SerializeField] private TextMeshProUGUI str;


    private void Update()
    {
        if(Square1.color == Color.green)
        {
            flag1 = true;
        }
        if (Square2.color == Color.green)
        {
            flag2 = true;
        }
        if (Square3.color == Color.green)
        {
            flag3 = true;
        }

        if(Pass == "")
        {
            str.text = "Pass Strength: No Password";
            str.color = Color.black;
        }
        else if (Pass != "")
        {
            str.text = "Pass Strength: Weak";
            str.color = Color.red;
        }
        
        if(flag1)
        {
            str.text = "Pass Strength: Weak";
            str.color = Color.red;
        }
        
        if (flag2)
        {
            str.text = "Pass Strength: Fair";
            str.color = Color.yellow;
        }
        
        if (flag3)
        {
            str.text = "Pass Strength: Strong";
            str.color = Color.green;
        }
    }


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
   

