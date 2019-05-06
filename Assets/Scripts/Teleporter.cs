using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleporter : MonoBehaviour {
	public GameObject other;
	public bool active;
	Teleporter otherScript;
	public int count;
	GameObject Room;
	public GameObject teleporter;
	public GameObject[] rooms;
	public AudioClip[] music;
	public int SourceRoomTheme;
	public int TargetRoomTheme;
	public string[] roomTypes;
	public bool locked;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider target){
		if (target.gameObject.tag == "Player" && active && !locked) {
			if (other == null) {
				TargetRoomTheme = Random.Range (0, 3);
				Room = rooms [TargetRoomTheme];
				GameObject newFloorRoom = Instantiate (Room, new Vector3 (Random.Range (-10000, 10000) + 0.5f, 0, Random.Range (-10000, 10000) + 0.5f), Quaternion.identity);
				newFloorRoom.GetComponent<LayoutGen> ().count = 0;
				newFloorRoom.GetComponent<LayoutGen> ().tier++;
				newFloorRoom.name = rooms [TargetRoomTheme].name;
				GameObject child = Instantiate (teleporter, newFloorRoom.gameObject.transform.position + new Vector3 (0, 3, 0), Quaternion.identity);
				other = child;
				otherScript = other.GetComponentInChildren<Teleporter> ();
				child.GetComponentInChildren<Teleporter> ().other = transform.parent.gameObject;
				child.GetComponentInChildren<Teleporter> ().otherScript = GetComponent<Teleporter> ();
				child.GetComponentInChildren<Teleporter> ().SourceRoomTheme = TargetRoomTheme;
				child.GetComponentInChildren<Teleporter> ().TargetRoomTheme = SourceRoomTheme;
				GameObject.Find ("Controller").GetComponent<Doorstopper> ().Fill ();

			}
			Camera.main.GetComponent<AudioSource> ().clip = music [TargetRoomTheme];
			Camera.main.GetComponent<AudioSource> ().Play ();
			otherScript.active = false;
			target.gameObject.transform.position = other.transform.position;
		}

	}
	void OnTriggerExit(Collider target){
		if (target.gameObject.tag == "Player" && !locked) {
			active = true;
		}
	}
}
