using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public enum ConsType { Potion, Arrow };

    public ConsType TypeC;
    public int Magnitude;
    public int Amount;

    void Start ()
    {
		
	}
	
	void Update ()
    {

	}
}
