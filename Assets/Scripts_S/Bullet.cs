using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "CustomObject/Bullet", order = 2)]

public class Bullet : ScriptableObject
{
    public string Name;
    public float Damage;
    public float Velocity;
}

