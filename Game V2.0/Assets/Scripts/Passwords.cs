using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passwords : MonoBehaviour
{
    static public string Pass;
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
}
   

