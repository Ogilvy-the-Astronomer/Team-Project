using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemTemplates
{
    static readonly List<Weapon> WeaponList;
    static readonly List<Armour> ArmourList;
    static readonly List<Consumable> ConsumableList;
    //static readonly List<Enemy> EnemyList;

    static ItemTemplates()
    {
        WeaponList = new List<Weapon>();
		ArmourList = new List<Armour>();
        ConsumableList = new List<Consumable>();
        InitializeWeapons();
        InitializeArmours();
        InitializeConsumables();
        //InitializeEnemies();
        //whatever other stuff
    }

    public static void ConstructWeapon(ref Weapon W, int index)
    {
        W.Index = index;
        W.Name = WeaponList[index].Name;
        W.TypeI = ItemType.Weapon;
        W.PlusBonus = 0;
        W.Value = WeaponList[index].Value;
        W.TypeW = WeaponList[index].TypeW;
        W.Damage = WeaponList[index].Damage;
        W.Element = WeaponList[index].Element;
        W.Speed = WeaponList[index].Speed;
        W.TwoHanded = WeaponList[index].TwoHanded;
        W.Enchantment = WeaponList[index].Enchantment;
        W.EnchMagnitude = WeaponList[index].EnchMagnitude;
    }
    private static void InitializeWeapons()
    {
		for (int i = 0; i < 20; i++)
			WeaponList.Add(new Weapon());
        for (int i = 0; i < WeaponList.Count; i++)
        {
            WeaponList[i] = new Weapon();
            WeaponList[i].Index = i;
            WeaponList[i].TypeI = ItemType.Weapon;
            WeaponList[i].PlusBonus = 0;
            WeaponList[i].Enchantment = "";
            WeaponList[i].EnchMagnitude = 0;
            switch (i)
            {
                #region 0-19
                case 0:
                    {
                        WeaponList[i].Name = "Basic Sword";
                        WeaponList[i].Value = -1;
                        WeaponList[i].Damage = 4;
                    }
                    break;
                case 1:
                    {
                        WeaponList[i].Name = "Shortsword";
                        WeaponList[i].Value = 1;
                        WeaponList[i].Damage = 10;
                    }
                    break;
                case 2:
                    {
                        WeaponList[i].Name = "Longsword";
                        WeaponList[i].Value = 2;
                        WeaponList[i].Damage = 15;
                    }
                    break;
                case 3:
                    {
                        WeaponList[i].Name = "Claymore";
                        WeaponList[i].Value = 3;
                        WeaponList[i].Damage = 20;
                    }
                    break;
                case 4:
                    {
                        WeaponList[i].Name = "Bloodskal Blade";
                        WeaponList[i].Value = 4;
                        WeaponList[i].Damage = 100;
                    }
                    break;
                case 5:
                    {
                        WeaponList[i].Name = "Cleaver";
                        WeaponList[i].Value = 0;
                        WeaponList[i].Damage = 7;
                    }
                    break;
                case 6:
                    {
                        WeaponList[i].Name = "Hand Axe";
                        WeaponList[i].Value = 1;
                        WeaponList[i].Damage = 8;
                    }
                    break;
                case 7:
                    {
                        WeaponList[i].Name = "War Axe";
                        WeaponList[i].Value = 2;
                        WeaponList[i].Damage = 17;
                    }
                    break;
                case 8:
                    {
                        WeaponList[i].Name = "Battle Axe";
                        WeaponList[i].Value = 3;
                        WeaponList[i].Damage = 24;
                    }
                    break;
                case 9:
                    {
                        WeaponList[i].Name = "Earth Splitter";
                        WeaponList[i].Value = 4;
                        WeaponList[i].Damage = 75;
                    }
                    break;
                case 10:
                    {
                        WeaponList[i].Name = "Club";
                        WeaponList[i].Value = 0;
                        WeaponList[i].Damage = 8;
                    }
                    break;
                case 11:
                    {
                        WeaponList[i].Name = "Wood Flail";
                        WeaponList[i].Value = 1;
                        WeaponList[i].Damage = 12;
                    }
                    break;
                case 12:
                    {
                        WeaponList[i].Name = "Mace";
                        WeaponList[i].Value = 2;
                        WeaponList[i].Damage = 19;
                    }
                    break;
                case 13:
                    {
                        WeaponList[i].Name = "War Hammer";
                        WeaponList[i].Value = 3;
                        WeaponList[i].Damage = 25;
                    }
                    break;
                case 14:
                    {
                        WeaponList[i].Name = "The Morning Star";
                        WeaponList[i].Value = 4;
                        WeaponList[i].Damage = 34;
                    }
                    break;
                case 15:
                    {
                        WeaponList[i].Name = "Pointy Fishing Rod";
                        WeaponList[i].Value = 0;
                        WeaponList[i].Damage = 6;
                    }
                    break;
                case 16:
                    {
                        WeaponList[i].Name = "Spear";
                        WeaponList[i].Value = 1;
                        WeaponList[i].Damage = 12;
                    }
                    break;
                case 17:
                    {
                        WeaponList[i].Name = "Lance";
                        WeaponList[i].Value = 2;
                        WeaponList[i].Damage = 17;
                    }
                    break;
                case 18:
                    {
                        WeaponList[i].Name = "Ancient Trident";
                        WeaponList[i].Value = 3;
                        WeaponList[i].Damage = 29;
                    }
                    break;
                case 19:
                    {
                        WeaponList[i].Name = "Brionac";
                        WeaponList[i].Value = 4;
                        WeaponList[i].Damage = 66;
                    }
                    break;
                    #endregion
            }
        }
    }
	public static void ConstructArmour(ref Armour A, int index)
	{
		A.Index = index;
		A.Name = ArmourList[index].Name;
		A.Resistances = ArmourList [index].Resistances;
		A.TypeI = ItemType.Armour;
		A.PlusBonus = 0;
	}
    private static void InitializeArmours()
    {	
		
		for (int i = 0; i < 15; i++) {
			ArmourList.Add(new Armour());
		}
		for (int i = 0; i < ArmourList.Count; i++)
        {
            ArmourList[i] = new Armour();
            ArmourList[i].Index = i;
            ArmourList[i].TypeI = ItemType.Armour;
            // any other default armour stuff
            switch (i)
            {
                #region 0-14
                case 0:
                    {
                        ArmourList[i].Name = "Basic Armour";
                        ArmourList[i].Resistances[0] = 0;
                        ArmourList[i].Value = -1;
                    }
                    break;
                case 1:
                    {
                        ArmourList[i].Name = "Leather Armour";
                        ArmourList[i].Resistances[0] = 5;
                        ArmourList[i].Value = 1;
                    }
                    break;
                case 2:
                    {
                        ArmourList[i].Name = "Chainmail";
                        ArmourList[i].Resistances[0] = 10;
                        ArmourList[i].Value = 2;
                    }
                    break;
                case 3:
                    {
                        ArmourList[i].Name = "Halfplate";
                        ArmourList[i].Resistances[0] = 15;
                        ArmourList[i].Value = 3;
                    }
                    break;
                case 4:
                    {
                        ArmourList[i].Name = "Fullplate";
                        ArmourList[i].Resistances[0] = 25;
                        ArmourList[i].Value = 4;
                    }
                    break;
                case 5:
                    {
                        ArmourList[i].Name = "Winter Coat";
                        ArmourList[i].Resistances[0] = 3;
                        ArmourList[i].Value = 0;
                    }
                    break;
                case 6:
                    {
                        ArmourList[i].Name = "Scavenger Outfit";
                        ArmourList[i].Resistances[0] = 7;
                        ArmourList[i].Value = 1;
                    }
                    break;
                case 7:
                    {
                        ArmourList[i].Name = "Boiled Leather Armour";
                        ArmourList[i].Resistances[0] = 13;
                        ArmourList[i].Value = 2;
                    }
                    break;
                case 8:
                    {
                        ArmourList[i].Name = "Unknown Soldier's Uniform";
                        ArmourList[i].Resistances[0] = 16;
                        ArmourList[i].Value = 3;
                    }
                    break;
                case 9:
                    {
                        ArmourList[i].Name = "Olden Paladin Armour";
                        ArmourList[i].Resistances[0] = 21;
                        ArmourList[i].Value = 4;
                    }
                    break;
                case 10:
                    {
                        ArmourList[i].Name = "Nameless Outfit";
                        ArmourList[i].Resistances[0] = 4;
                        ArmourList[i].Value = 0;
                    }
                    break;
                case 11:
                    {
                        ArmourList[i].Name = "Padded Armour";
                        ArmourList[i].Resistances[0] = 6;
                        ArmourList[i].Value = 1;
                    }
                    break;
                case 12:
                    {
                        ArmourList[i].Name = "Ice Armour";
                        ArmourList[i].Resistances[0] = 11;
                        ArmourList[i].Value = 2;
                    }
                    break;
                case 13:
                    {
                        ArmourList[i].Name = "Cavalier's Armour";
                        ArmourList[i].Resistances[0] = 16;
                        ArmourList[i].Value = 3;
                    }
                    break;
                case 14:
                    {
                        ArmourList[i].Name = "Crystal Golem's Remains";
                        ArmourList[i].Resistances[0] = 28;
                        ArmourList[i].Value = 4;
                    }
                    break;
                    #endregion
            }
    	}
	}
    private static void InitializeConsumables()
    {
        for (int i = 0; i < ConsumableList.Count; i++)
        {
            ConsumableList[i] = new Consumable();
            ConsumableList[i].Index = i;
            ConsumableList[i].TypeI = ItemType.Consumable;
            // any other default consumable stuff
            switch (i)
            {
                #region 0-
                case 0:
                    break;
                case 1:
                    break;
                    #endregion
            }
        }
    }

	public static Weapon GetWeaponOfTier(int tier){
		List<Weapon> tempList = new List<Weapon>();
		for (int i = 0; i < WeaponList.Count; i++) {
			if (WeaponList [i].Value == tier) {
				tempList.Add (WeaponList [i]);
			}
		}
		Weapon returnw = tempList [Random.Range (0, tempList.Count)];
		return returnw;
	}

	public static Armour GetArmourOfTier(int tier){
		List<Armour> tempList = new List<Armour>();
		for (int i = 0; i < ArmourList.Count; i++) {
			if (ArmourList [i].Value == tier) {
				tempList.Add (ArmourList [i]);
			}
		}
		Armour returnw = tempList [Random.Range (0, tempList.Count)];
		return returnw;
	}
    //private static void InitializeEnemies()
}
