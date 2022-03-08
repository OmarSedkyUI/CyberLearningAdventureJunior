using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void LevelCompleted();
    public static event LevelCompleted OnLevelCompleted;

    public static void LevelCompletedMethod()
    {
        if (OnLevelCompleted != null)
            OnLevelCompleted();
    }
    //**************************************************
    public delegate void UnlockNextPuzzle();
    public static event UnlockNextPuzzle OnUnlockNextPuzzle;

    public static void UnlockNextPuzzleMethod()
    {
        if (OnUnlockNextPuzzle != null)
            OnUnlockNextPuzzle();
    }
    //**************************************************
    public delegate void LoadNextLevel();
    public static event LoadNextLevel OnLoadNextLevel;

    public static void LoadNextLevelMethod()
    {
        if (OnLoadNextLevel != null)
            OnLoadNextLevel();
    }
    //**************************************************
}
