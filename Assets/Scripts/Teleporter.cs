using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	public GameObject other;
	public bool active;
	Teleporter otherScript;
	public int count;
	// Use this for initialization
	void Start () {
		active = true;
		otherScript = other.GetComponentInChildren<Teleporter> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag == "Player" && active) {
			otherScript.active = false;
			target.gameObject.transform.position = other.transform.position;
		}
	}
	void OnTriggerExit(Collider target){
		if (target.gameObject.tag == "Player") {
			active = true;
		}
	}
}
