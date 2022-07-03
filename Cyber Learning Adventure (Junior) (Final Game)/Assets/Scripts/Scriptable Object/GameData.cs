using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public string UserUsername;
    public string UserPassword;
    public string LastScene;
    public bool Level1 = true;
    public bool Level2;
    public bool Level3;

    public int CurrentSkin;

    public bool Lotus;
    public bool Carnage;
    public bool Metal;
    public bool Golden;
    public bool Invisible;
}