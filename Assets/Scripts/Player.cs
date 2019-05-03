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


	public Vector3 AttackDir;
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
			//Debug.Log ("Attack up");
			AttackDir = Vector3.forward;
			Attack ();
		}
	}
	//yes I'm aware that attck right sets the attack direction to left and visa versa, for some reason that's the only way it works. Don't rename the functions cuz they correspond to which button calls them
	public void AttackRight(){
		if (standardAction) {
			Attack ();
			AttackDir = Vector3.left;
			//Debug.Log ("Attack left");
		}
	}
	public void AttackDown(){
		if (standardAction) {
			Attack ();
			AttackDir = Vector3.back;
			//Debug.Log ("Attack down");
		}
	}
	public void AttackLeft(){
		if (standardAction) {
			Attack ();
			AttackDir = Vector3.right;
			//Debug.Log ("Attack right");
		}
	}
	void Attack(){
		//standardAction = false;
		RaycastHit hit;
		if(Physics.Raycast (new Ray (transform.position + Vector3.up, AttackDir), out hit, 1f)){
			if (hit.collider.tag == "Enemy") {
				hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
				Debug.Log ("Attack hit\n ######");
			}
		}
		GetComponent<Animator> ().Play ("Attack");
		AttackDir = Vector3.zero;
	}
}
