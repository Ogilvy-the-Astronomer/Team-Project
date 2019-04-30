using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public int health;
	Vector3 playerPos;
	Vector3[] possiblepositions = new Vector3[5];
	Vector3[] dirList = new Vector3[4];
	// Use this for initialization
	void Start () {
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
		
	}

	public void TakeDamage(int damage){
		health -= damage;
	}

	public void DoTurn(){
		if (Attack () == false) {
			Move ();
			Attack ();
		} else {
			//Move ();
		}
	}

	void Move(){
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		if (playerPos.x > transform.position.x && !Physics.Raycast(new Ray(transform.position,transform.right),1f)) {
			transform.Translate (new Vector3 (1, 0, 0));
		}
		if (playerPos.x < transform.position.x && !Physics.Raycast(new Ray(transform.position,-transform.right),1f)) {
			transform.Translate (new Vector3 (-1, 0, 0));
		}
		if (playerPos.z > transform.position.z && !Physics.Raycast(new Ray(transform.position,transform.forward),1f)) {
			transform.Translate (new Vector3 (0, 0, 1));
		}
		if (playerPos.z < transform.position.z && !Physics.Raycast(new Ray(transform.position,-transform.forward),1f)) {
			transform.Translate (new Vector3 (0, 0, -1));
		}
	}
		
	bool Attack(){
		RaycastHit hit;
		for (int i = 0; i < dirList.Length; i++) {
			if (Physics.Raycast (transform.position, dirList [i], out hit, 1f)) {
				if (hit.collider.tag == "Player") {
					//do damage
					Debug.Log("Player attacked");
					return true;
				}
			}
		}
		return false;
	}
}
