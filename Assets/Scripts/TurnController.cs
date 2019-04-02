﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			EndTurn ();
		}
	}

	public void EndTurn() {
		Debug.Log ("Turn Ended");
		player.GetComponent<PlayerController> ().BeginTurn ();
	}
}