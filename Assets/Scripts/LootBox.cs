using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour {
	public LootTables table;
	public int tier;
	public Player player;
	public Weapon w;
	public Armour a;
	public int Damage;
	// Use this for initialization
	void Start () {
		table = GameObject.Find ("Controller").GetComponent<LootTables> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();
		int i = Random.Range (0, 100);
		if (name.Contains ("Wbox")) {
			//int result = table.Weapons [tier] [i];
			w = ItemTemplates.GetWeaponOfTier (tier);
			Damage = w.Damage;

		} else if (name.Contains ("Abox")) {
			//int result = table.Armour [tier] [i];
			a = ItemTemplates.GetArmourOfTier (tier);
			Damage = (int)a.Resistances [0];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void DoLoot(){
		if (name.Contains ("Pbox")) {
			GivePotion ();
			Destroy (gameObject);
		} else if (name.Contains ("Abox")) {
			SwapArmour ();
		} else if (name.Contains ("Wbox")) {
			SwapWeapon ();
		}
	}

	void GivePotion(){
		int i = Random.Range (0, 100);
		int result = table.EnemyDrops [tier] [i];
		result = i / 25;
		switch (result) {
		case 0:
			{
				break;
			}
		case 1:
			{
				player.HealthPotions++;
				break;
			} 
		case 2:
			{
				player.BuffPotions++;
				break;
			}
		case 3:
			{
				player.DefensePotions++;
				break;
			}
		}
	}

	void SwapWeapon(){
		Weapon tempweapon = player.WeaponPrimary;
		player.WeaponPrimary = w;
		w = tempweapon;
	}

	void SwapArmour(){
		Armour temparmour = player.ArmourPrimary;
		player.ArmourPrimary = a;
		a = temparmour;
	}
}
