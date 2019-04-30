using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	public GameObject other;
	public bool active;
	Teleporter otherScript;
	public int count;
	public GameObject Room;
	public GameObject teleporter;
	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag == "Player" && active) {
			if (other == null) {
				GameObject newFloorRoom = Instantiate (Room, new Vector3 (Random.Range (-10000, 10000), 0, Random.Range (-10000, 10000)), Quaternion.identity);
				newFloorRoom.GetComponent<LayoutGen> ().count = 0;
				GameObject child = Instantiate (teleporter, newFloorRoom.gameObject.transform.position + new Vector3 (0, 3, 0), Quaternion.identity);
				other = child;
				otherScript = other.GetComponentInChildren<Teleporter> ();
				child.GetComponentInChildren<Teleporter> ().other = transform.parent.gameObject;
				child.GetComponentInChildren<Teleporter> ().otherScript = GetComponent<Teleporter> ();
				GameObject.Find ("Controller").GetComponent<Doorstopper> ().Fill ();

			}
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
