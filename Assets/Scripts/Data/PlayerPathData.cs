using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerPathData : ScriptableObject
{
    public Action OnEnd;
    public Action OnStart;
}
