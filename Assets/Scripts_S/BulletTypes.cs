using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "CustomObject/Bullet", order = 2)]

public class BulletType : ScriptableObject
{
    public string Name;
    public float Damage;
}

