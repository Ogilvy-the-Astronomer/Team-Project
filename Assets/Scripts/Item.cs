using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Consumable, Weapon, Armour };
public enum WeapType { Light, Heavy, Ranged, Wand };
public enum ArmType { Light, Heavy, Robes };
public enum ConsType { Potion, Arrow };


public class Item
{
    public int Index;
    public string Name;
    public ItemType TypeI;
    public int PlusBonus;
    public int Value;
    public bool Equippable;
    public Mesh Model;
    public Material Texture;

    void Start() { }
    void Update() { }
}
