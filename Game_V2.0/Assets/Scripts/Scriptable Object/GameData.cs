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

    public bool Skin1;
    public bool Skin2;
    public bool Skin3;
    public bool Skin4;
    public bool Skin5;
    public bool Skin6;
}