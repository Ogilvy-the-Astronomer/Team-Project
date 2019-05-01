using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Consumable, Weapon, Armour };

    public int Index;
    public string Name;
    public ItemType TypeI;
    public int PlusBonus;
    public int Value;
    public bool Equippable;
    //model
    //icon

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}
}
