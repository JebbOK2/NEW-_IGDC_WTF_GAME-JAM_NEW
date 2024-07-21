using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Scriptable Objects/Item")]

public class itemSo : ScriptableObject 
{
    public float cooldown;
    public itemType item_type;
    public Sprite item_sprite;
    public bool isPaper;
}

public enum itemType { Sword, Axe, Daggar, SciFiSword, paper, element1, element2, element3}
 