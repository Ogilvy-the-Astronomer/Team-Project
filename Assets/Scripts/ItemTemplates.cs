using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemTemplates
{
    static readonly Dictionary<string, Weapon> WeaponList;
    static readonly Dictionary<string, Armour> ArmourList;
    static readonly Dictionary<string, Consumable> ConsumableList;
    //static readonly Dictionary<string, Enemy> EnemyList;

    static ItemTemplates()
    {
        InitializeWeapons();
        InitializeArmours();
        InitializeConsumables();
    }

    public static void ConstructWeapon(ref Weapon W, int index)
    {
        W.Index = index;
        W.Name = WeaponList[index].Name;
        W.Type = ItemType.Weapon;
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
        for (int i = 0; i < WeaponList.Count; i++)
        {
            WeaponList[i] = new Weapon();
            WeaponList[i].Index = i;
            WeaponList[i].Type = ItemType.Weapon;
            WeaponList[i].PlusBonus = 0;
            WeaponList[i].Enchantment = "";
            WeaponList[i].EnchMagnitude = 0;
            switch (i)
            {
                #region 0-
                case 0:
                    {
                        WeaponList[i].Name = "Bloodskal Blade";
                        WeaponList[i].Value = 100;
                        WeaponList[i].TypeW = WeapType.Heavy;
                        WeaponList[i].Speed = 0.5f;
                        WeaponList[i].TwoHanded = true;

                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                    #endregion
            }
        }
    }
    private static void InitializeArmours()
    {
        for (int i = 0; i < ArmourList.Count; i++)
        {
            ArmourList[i] = new Armour();
            ArmourList[i].Index = i;
            ArmourList[i].Type = ItemType.Armour;
            // any other default armour stuff
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
    private static void InitializeConsumables()
    {
        for (int i = 0; i < ConsumableList.Count; i++)
        {
            ConsumableList[i] = new Consumable();
            ConsumableList[i].Index = i;
            ConsumableList[i].Type = ItemType.Consumable;
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
    //private static void InitializeEnemies()
}
