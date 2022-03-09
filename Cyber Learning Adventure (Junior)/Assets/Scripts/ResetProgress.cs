using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public GameLevelData gameLevelData;
    public void Reset()
    {
        DataSaver.ClearGameData(gameLevelData);
    }
}
