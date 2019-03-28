using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float sensitivity;
	public float jumpForce;
	public GameObject root;

	public bool moveAction;
	public bool standardAction;
	// Use this for initialization
	void Start () {
		moveAction = true;
		standardAction = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveAction) {
			if (Input.GetKeyDown(KeyCode.W) && !Physics.Raycast(new Ray(transform.position,transform.forward),5f)) {
				transform.Translate (transform.forward);
				moveAction = false;
				Debug.Log ("Player moved");
			}
			if (Input.GetKeyDown(KeyCode.S) && !Physics.Raycast(new Ray(transform.position,-transform.forward),5f)) {
				transform.Translate (-transform.forward);
				moveAction = false;
				Debug.Log ("Player moved");
			}
			if (Input.GetKeyDown(KeyCode.D) && !Physics.Raycast(new Ray(transform.position,transform.right),5f)) {
				transform.Translate (transform.right);
				moveAction = false;
				Debug.Log ("Player moved");
			}
			if (Input.GetKeyDown(KeyCode.A) && !Physics.Raycast(new Ray(transform.position,-transform.right),5f)) {
				transform.Translate (-transform.right);
				moveAction = false;
				Debug.Log ("Player moved");
			}
		}
	}

	public void BeginTurn(){
		moveAction = true;
		standardAction = true;
	}
}
