using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public int health;
	Vector3 playerPos;
	Vector3[] possiblepositions = new Vector3[5];
	Vector3[] dirList = new Vector3[4];
	public float distance;
	bool isMoving;
	public Vector3 MoveDir;
	public float moveSpeed;
	int moveCounter;

	public bool xplus = false;
	public bool xminus = false;
	public bool zplus = false;
	public bool zminus = false;
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
		if (isMoving) {
			if (moveCounter < 1 / moveSpeed) {
				transform.Translate (MoveDir / (1 / moveSpeed));
				moveCounter++;

			} else {
				transform.position = new Vector3 (Mathf.Round (transform.position.x), transform.position.y, Mathf.Round (transform.position.z));
				isMoving = false;
				moveCounter = 0;
				Attack ();
			}
		}
	}

	public void TakeDamage(int damage){
		health -= damage;
	}

	public void DoTurn(){
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		distance = Vector3.Distance (transform.position, playerPos);
		if (distance < 20) {
			if (Attack () == false) {
				Move ();
			} else {
				Move ();
			}
		}
	}

	void Move(){
		xplus = xminus = zplus = zminus = false;
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		if (playerPos.x > transform.position.x && !Physics.Raycast(new Ray(transform.position,Vector3.right),1f)) {
			MoveDir = (new Vector3 (1, 0, 0));
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 90;
			isMoving = true;
			xplus = true;
		}
		else if (playerPos.x < transform.position.x && !Physics.Raycast(new Ray(transform.position, Vector3.left),1f)) {
			MoveDir = (new Vector3 (-1, 0, 0));
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 270;
			isMoving = true;
			xminus = true;
		}
		if (playerPos.z > transform.position.z && !Physics.Raycast(new Ray(transform.position, Vector3.forward),1f)) {
			MoveDir = (new Vector3 (0, 0, 1));
			transform.GetChild(0).transform.eulerAngles = Vector3.up * 0;
			isMoving = true;
			zplus = true;
		}
		else if (playerPos.z < transform.position.z && !Physics.Raycast(new Ray(transform.position, Vector3.back),1f)) {
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
	}
		
	bool Attack(){
		RaycastHit[] hits;
		for (int i = 0; i < dirList.Length; i++) {
			hits = Physics.RaycastAll (transform.position, dirList [i], 1f);
			foreach (RaycastHit hit in hits) {
				if (hit.collider.tag == "Player") {
					//do damage
					GetComponent<Animator> ().SetTrigger("isAttacking");
					return true;
				}
			}
		}
		return false;
	}
}
