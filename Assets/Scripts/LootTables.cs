using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTables : MonoBehaviour {
	
	public List<List<int>> EnemyDrops = new List<List<int>>();
	public List<List<int>> Weapons = new List<List<int>>();
	public List<List<int>> Armour = new List<List<int>>();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			EnemyDrops.Add(new List<int>());
			Weapons.Add(new List<int>());
			Armour.Add(new List<int>());
		}
		for (int i = 0; i < 100; i++) {
			int k = Random.Range (0, 100);
			if (k < 66) {
				EnemyDrops [0].Add(0);
			} else if (k < 5) {
				EnemyDrops [0].Add(1);
			} else if (k < 95) {
				EnemyDrops [0].Add(2);
			} else if (k < 100) {
				EnemyDrops [0].Add(3);
			}

			k = Random.Range (0, 100);
			if (k < 40) {
				EnemyDrops [1].Add(0);
			} else if (k < 5) {
				EnemyDrops [1].Add(1);
			} else if(k < 90){
				EnemyDrops [1].Add(2);
			} else if (k < 100) {
				EnemyDrops [1].Add(3);
			}

			k = Random.Range (0, 100);
			if (k < 25) {
				EnemyDrops [2].Add(0);
			} else if (k < 5) {
				EnemyDrops [2].Add(1);
			} else if(k < 90){
				EnemyDrops [2].Add(2);
			} else if (k < 100) {
				EnemyDrops [2].Add(3);
			}

			k = Random.Range (0, 100);
			if (k < 10) {
				EnemyDrops [3].Add(0);
			} else if (k < 5) {
				EnemyDrops [3].Add(1);
			} else if(k < 70){
				EnemyDrops [3].Add(2);
			} else if (k < 100) {
				EnemyDrops [0].Add(3);
			}

			k = Random.Range (0, 100);
			if (k < 70) {
				Weapons [0].Add(0);
			} else if (k < 95) {
				Weapons [0].Add(1);
			} else if(k < 100){
				Weapons [0].Add(2);
			} else if(k < 101){
				Weapons [0].Add(3);
			} else if(k < 101){
				Weapons [0].Add(4);
			}

			k = Random.Range (0, 100);
			if (k < 20) {
				Weapons [1].Add(0);
			} else if (k < 70) {
				Weapons [1].Add(1);
			} else if(k < 90){
				Weapons [1].Add(2);
			} else if(k < 100){
				Weapons [1].Add(3);
			} else if(k < 101){
				Weapons [1].Add(4);
			}

			k = Random.Range (0, 100);
			if (k < 5) {
				Weapons [2].Add(0);
			} else if (k < 20) {
				Weapons [2].Add(1);
			} else if(k < 80){
				Weapons [2].Add(2);
			} else if(k < 98){
				Weapons [2].Add(3);
			} else if(k < 100){
				Weapons [2].Add(4);
			}

			k = Random.Range (0, 100);
			if (k < 1) {
				Weapons [3].Add(0);
			} else if (k < 5) {
				Weapons [3].Add(1);
			} else if(k < 15){
				Weapons [3].Add(2);
			} else if(k < 90){
				Weapons [3].Add(3);
			} else if(k < 100){
				Weapons [3].Add(4);
			}

			k = Random.Range (0, 100);
			if (k < 70) {
				Armour [0].Add(0);
			} else if (k < 95) {
				Armour [0].Add(1);
			} else if(k < 100){
				Armour [0].Add(2);
			} else if(k < 101){
				Armour [0].Add(3);
			} else if(k < 101){
				Armour [0].Add(4);
			}

			k = Random.Range (0, 100);
			if (k < 20) {
				Armour [1].Add(0);
			} else if (k < 70) {
				Armour [1].Add(1);
			} else if(k < 90){
				Armour [1].Add(2);
			} else if(k < 100){
				Armour [1].Add(3);
			} else if(k < 101){
				Armour [1].Add(4);
			}

			k = Random.Range (0, 100);
			if (k < 5) {
				Armour [2].Add(0);
			} else if (k < 20) {
				Armour [2].Add(1);
			} else if(k < 80){
				Armour [2].Add(2);
			} else if(k < 98){
				Armour [2].Add(3);
			} else if(k < 100){
				Armour [2].Add(4);
			}

			k = Random.Range (0, 100);
			if (k < 1) {
				Armour [3].Add(0);
			} else if (k < 5) {
				Armour [3].Add(1);
			} else if(k < 15){
				Armour [3].Add(2);
			} else if(k < 90){
				Armour [3].Add(3);
			} else if(k < 100){
				Armour [3].Add(4);
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
