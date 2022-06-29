using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public string UserPassword;
    public bool Level1 = true;
    public bool Level2;
    public bool Level3;
}
