using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { Physical, Fire, Frost, Earth, Electric };

public class Weapon : Item
{
    

    public WeapType TypeW;
    public int Damage;
    public Element Element;
    public float Speed; // speed of attacking
    public bool TwoHanded;
    public string Enchantment;
    public int EnchMagnitude;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        
	}
}
