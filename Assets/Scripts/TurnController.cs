using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
	public GameObject player;
	public int turnCooldown;
	// Use this for initialization
	void Start () {
		turnCooldown = 121;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			EndTurn ();
		}
		if (turnCooldown < 60)
			turnCooldown++;
	}

	public void EndTurn() {
		if (turnCooldown >= 60) {
			player.GetComponent<Player> ().BeginTurn ();
			GameObject[] enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0; i < enemyList.Length; i++) {
				enemyList [i].GetComponent<EnemyController> ().DoTurn ();
			}
			turnCooldown = 0;
		} 
	}
}
