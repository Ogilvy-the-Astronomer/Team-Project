using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// movement variables
	public float moveSpeed;
	public float sensitivity;
	public float jumpForce;
	public GameObject root;
	public bool isMoving;
	public Vector3 MoveDir;
	float moveCounter;

	// equipment variables
	public Weapon WeaponPrimary;
	public Item WeaponSecondary;
	public Armour ArmourPrimary;


	public bool moveAction;
	public bool standardAction;
	// Use this for initialization
	void Start () {
		moveAction = true;
		standardAction = true;
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = transform.position + new Vector3 (0, 75, 0);
		if (moveAction) {
			if (Input.GetKey(KeyCode.W) && !Physics.Raycast(new Ray(transform.position + Vector3.up,Vector3.forward),1f)) {
				//transform.Translate (Vector3.forward);
				moveAction = false;
				MoveDir = Vector3.forward;
				isMoving = true;
				root.transform.eulerAngles = new Vector3 (0, 0, 0);
				//Debug.Log ("Player moved");
			}
			if (Input.GetKey(KeyCode.S) && !Physics.Raycast(new Ray(transform.position + Vector3.up,-Vector3.forward),1f)) {
				//transform.Translate (-Vector3.forward);
				moveAction = false;
				MoveDir = -Vector3.forward;
				isMoving = true;
				root.transform.eulerAngles = new Vector3 (0, 180, 0);
				//Debug.Log ("Player moved");
			}
			if (Input.GetKey(KeyCode.D) && !Physics.Raycast(new Ray(transform.position + Vector3.up,Vector3.right),1f)) {
				//transform.Translate (Vector3.right);
				moveAction = false;
				MoveDir = Vector3.right;
				isMoving = true;
				root.transform.eulerAngles = new Vector3 (0, 90, 0);
				//Debug.Log ("Player moved");
			}
			if (Input.GetKey(KeyCode.A) && !Physics.Raycast(new Ray(transform.position + Vector3.up,-Vector3.right),1f)) {
				//transform.Translate (-Vector3.right);
				moveAction = false;
				MoveDir = -Vector3.right;
				isMoving = true;
				root.transform.eulerAngles = new Vector3 (0,270, 0);
				//Debug.Log ("Player moved");
			}
		}
		if (isMoving) {
			if (moveCounter < 1/moveSpeed) {
				GetComponent<Animator> ().SetBool ("isRunning", true);
				transform.Translate (MoveDir / (1/moveSpeed));
				moveCounter++;

			} else {
				isMoving = false;
				GetComponent<Animator> ().SetBool ("isRunning", false);
				moveAction = true;
				moveCounter = 0;
			}
		}
	}

	public void BeginTurn(){
		moveAction = true;
		standardAction = true;
	}

	public void AttackUp(){
		if (standardAction) {
			Debug.Log ("Attack up");
			standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, Vector3.forward), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
	public void AttackRight(){
		if (standardAction) {
			Debug.Log ("Attack left");
			standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, -Vector3.right), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
	public void AttackDown(){
		if (standardAction) {
			Debug.Log ("Attack down");
			standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, -Vector3.forward), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
	public void AttackLeft(){
		if (standardAction) {
			Debug.Log ("Attack right");
			standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, Vector3.right), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
}
