using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "CustomObject/Gun", order = 1)]

public class Gun : ScriptableObject
{
    public string Name;
    public float Firerate;
    public int AmmoCount;
    public Bullet bullet;
    public int Cooldown;
}

