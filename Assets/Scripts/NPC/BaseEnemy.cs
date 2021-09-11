using System;
using UnityEngine;

public abstract class BaseEnemy: MonoBehaviour
{
    public Action<string, Vector3> OnFound;
}