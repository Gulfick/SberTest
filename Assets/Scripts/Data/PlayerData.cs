using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public float PlayerSpeed;
    public float SprintModifier = 2;
    public float MouseSensitivity;
    public float JumpSpeed;
    public float Gravity;
    public float[] HeadLimit = {-80f, 70f};
    public bool IsMove = true;
}
