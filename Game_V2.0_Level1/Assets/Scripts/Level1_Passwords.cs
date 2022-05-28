using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using System.IO;

public class Level1_Passwords : MonoBehaviour
{
    static public string Pass = "";
    static public bool flag0;
    private bool flag11, flag21, flag31, flag12, flag22, flag32;
    static public int done;
    [SerializeField] private SpriteRenderer Square1;
    [SerializeField] private SpriteRenderer Square2;
    [SerializeField] private SpriteRenderer Square3;
    [SerializeField] private TextMeshProUGUI str;
    static private string[] namesArray;
    string fileName;
    string myFilePath;
    private void Start()
    {
        fileName = "1000-most-common-passwords.txt";
        myFilePath = Application.dataPath + "/" + fileName;
        namesArray = File.ReadAllLines(myFilePath);
        flag0 = true; flag11 = true; flag21 = true; flag31 = true; flag12 = false; flag22 = false; flag32 = false;
        done = -1;
    }

    private void Update()
    {
        
        if(Square1.color == Color.green && flag11)
        {
            done += 1;
            flag11 = false;
            flag12 = true;
        }

        if (Square1.color == Color.red && flag12)
        {
            done -= 1;
            flag11 = true;
            flag12 = false;
        }


        if (Square2.color == Color.green && flag21)
        {
            done += 1;
            flag21 = false;
            flag22 = true;
        }

        if (Square2.color == Color.red && flag22)
        {
            done -= 1;
            flag21 = true;
            flag22 = false;
        }


        if (Square3.color == Color.green && flag31)
        {
            done += 1;
            flag31 = false;
            flag32 = true;
        }

        if (Square3.color == Color.red && flag32)
        {
            done -= 1;
            flag31 = true;
            flag32 = false;
        }


        if (Pass == "")
        {
            str.text = "Pass Strength: No Password";
            str.color = Color.black;
        }

        if(Pass != "" && flag0)
        {
            done += 1;
            flag0 = false;
        }

        if (done == 0)
        {
            str.text = "Pass Strength: Weak";
            str.color = Color.red;
        }
        
        if(done == 1)
        {
            str.text = "Pass Strength: Weak";
            str.color = Color.red;
        }
        
        if (done == 2)
        {
            str.text = "Pass Strength: Fair";
            str.color = Color.yellow;
        }
        
        if (done == 3)
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

    static public bool CommonPassCheck()
    {
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
   

