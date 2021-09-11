using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoundGameData : ScriptableObject
{
    public Dictionary<string, bool> EnemiesStatus;
    public Action OnEnd;
    private string WinString = "You are winner!", LooseString = "You are loser";

    public string EndString()
    {
        return EnemiesStatus.ContainsValue(false) ? LooseString : WinString;
    }
}
