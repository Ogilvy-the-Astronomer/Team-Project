﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public bool isBoss;
	public int health;
	Vector3 playerPos;
	Vector3[] possiblepositions = new Vector3[5];
	Vector3[] dirList = new Vector3[4];
	public float distance;
	bool isMoving;
	public Vector3 MoveDir;
	public float moveSpeed;
	int moveCounter;
	public float size;
	public bool attackpass;
	public int tier;
	public int defence;
	public int damage;
	public float reachmodifier;
	bool isDead;
	public GameObject Pbox;

	public bool xplus = false;
	public bool xminus = false;
	public bool zplus = false;
	public bool zminus = false;
	// Use this for initialization
	void Start () {
		isDead = false;
		possiblepositions [0] = transform.position;
		possiblepositions [1] = transform.position + new Vector3 (1, 0, 0);
		possiblepositions [2] = transform.position - new Vector3 (1, 0, 0);
		possiblepositions [3] = transform.position + new Vector3 (0, 0, 1);
		possiblepositions [4] = transform.position - new Vector3 (0, 0, 1);

		dirList[0] = transform.forward;
		dirList[1] = -transform.forward;
		dirList[2] = transform.right;
		dirList[3] = -transform.right;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			isDead = true;
			GetComponent<Animator> ().SetBool ("isDead", true);
			DropLoot ();
			if (isBoss && health > -1000) {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().baseDamage += 5 * tier;
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().baseDefence += 5 * tier;
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().HealthMax += 10 * tier;
				health = -2000;
				tag = "Enemy";
				Teleporter[] list = GameObject.FindObjectsOfType<Teleporter> ();
				foreach (Teleporter item in list) {
					item.locked = false;
				}
			}
		}
		if (isMoving) {
			if (moveCounter < 1 / moveSpeed) {
				transform.Translate (MoveDir / (1 / moveSpeed));
				moveCounter++;

			} else {
				transform.position = new Vector3 (Mathf.Round (transform.position.x), transform.position.y, Mathf.Round (transform.position.z));
				isMoving = false;
				moveCounter = 0;
				if (attackpass == false) {
					Attack ();
				}
			}
		}
	}

	public void TakeDamage(int damage){
		damage -= defence;
		if (damage > 0) {
			health -= damage;
		}
	}

	public void DoTurn(){
		if (!isDead) {
			playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
			distance = Vector3.Distance (transform.position, playerPos);
			if (distance < 20) {
				attackpass = Attack ();
				if (attackpass == false) {
					Move ();
				}
			}
		}
	}

	void Move(){
		xplus = xminus = zplus = zminus = false;
		gameObject.layer = Physics.IgnoreRaycastLayer;
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		if (playerPos.x > transform.position.x && !Physics.BoxCast(transform.position, transform.localScale,Vector3.right, Quaternion.identity, size)) {
			MoveDir = (new Vector3 (1, 0, 0));
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 90;
			isMoving = true;
			xplus = true;
		}
		else if (playerPos.x < transform.position.x && !Physics.BoxCast(transform.position,transform.localScale, Vector3.left, Quaternion.identity, size)) {
			MoveDir = (new Vector3 (-1, 0, 0));
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 270;
			isMoving = true;
			xminus = true;
		}
		if (playerPos.z > transform.position.z && !Physics.BoxCast(transform.position,transform.localScale, Vector3.forward, Quaternion.identity, size)) {
			MoveDir = (new Vector3 (0, 0, 1));
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 0;
			isMoving = true;
			zplus = true;
		}
		else if (playerPos.z < transform.position.z && !Physics.BoxCast(transform.position, transform.localScale, Vector3.back, Quaternion.identity, size)) {
			MoveDir = (new Vector3 (0, 0, -1));
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 180;
			isMoving = true;
			zminus = true;
		}
		if (xplus || xminus || zplus || zminus) {
			GetComponent<Animator> ().SetTrigger ("isMoving");
		}
		#region yes I know how shit this is but it works ok

		if (xplus && zplus && Random.Range (0, 2) == 1){
			MoveDir = Vector3.right;
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 90;
		}
		if (xplus && zminus && Random.Range (0, 2) == 1){
			MoveDir = Vector3.right;
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 90;
		}
		if (xminus && zplus && Random.Range (0, 2) == 1){
			MoveDir = Vector3.left;
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 270;
		}
		if (xminus && zminus && Random.Range (0, 2) == 1){
			MoveDir = Vector3.left;
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 270;
		}
		#endregion
		gameObject.layer = 0;
	}
		
	bool Attack(){
		//RaycastHit[] hits;
		Collider[] hits;
		for (int i = 0; i < dirList.Length; i++) {
			//hits = Physics.RaycastAll (new Vector3(transform.position.x, playerPos.y, transform.position.x), dirList [i], size);
			//hits = Physics.BoxCastAll(GetComponent<BoxCollider>().center,GetComponent<BoxCollider>().size, dirList[i], Quaternion.identity, 1);
			hits = Physics.OverlapBox (transform.position + (dirList [i] * size), new Vector3(size,size,size)/reachmodifier);
			foreach (Collider hit in hits) {
				if (hit.gameObject.tag == "Player") {
					hit.gameObject.GetComponent<Player> ().TakeDamage (damage);
					GetComponent<Animator> ().SetTrigger("isAttacking");
					return true;
				}
			}
		}
		return false;
	}
	void DropLoot(){
		if (Random.Range (0, 4) == 3) {
			GameObject child = Instantiate (Pbox, transform.position, Quaternion.identity);
			child.GetComponent<LootBox> ().tier = tier - 1;
			child.name = "Pbox";
			Destroy (gameObject);
		}
	}
}
