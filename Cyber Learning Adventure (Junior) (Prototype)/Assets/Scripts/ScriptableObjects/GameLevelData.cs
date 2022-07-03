using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class GameLevelData : ScriptableObject
{
    [System.Serializable]
    public struct LevelRecord
    {
        public string levelName;
        public List<string> levelData;
    }

    public List<LevelRecord> data;
}
