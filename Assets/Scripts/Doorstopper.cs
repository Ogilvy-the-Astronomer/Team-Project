using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorstopper : MonoBehaviour {
	int rooms = 0;
	int prooms = -1;
	GameObject[] roomlist;
	public GameObject DoorStop;
	Vector3 zmOffset1 = new Vector3(-2.5f, 15, -22.5f);
	Vector3 zmOffset2 = new Vector3(2.5f, 15, -22.5f);
	Vector3 zpOffset1 = new Vector3(-2.5f, 15, 22.5f);
	Vector3 zpOffset2 = new Vector3(2.5f, 15, 22.5f);
	Vector3 xmOffset1 = new Vector3(-22.5f, 15, -2.5f);
	Vector3 xmOffset2 = new Vector3(-22.5f, 15, 2.5f);
	Vector3 xpOffset1 = new Vector3(22.5f, 15, -2.5f);
	Vector3 xpOffset2 = new Vector3(22.5f, 15, 2.5f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		roomlist = GameObject.FindGameObjectsWithTag ("Room");
		rooms = roomlist.Length;
		if (rooms == prooms) {
			Debug.Log ("Finished");
			Fill ();
			this.enabled = false;
		} else
			prooms = rooms;
	}

	public void Fill(){
		for (int i = 0; i < rooms; i++) {
			LayoutGen a = roomlist [i].GetComponent<LayoutGen> ();
			if (Physics.OverlapSphere (a.xPlus.transform.position, 5).Length < 1) {
				GameObject child = Instantiate (DoorStop, a.transform.position + xpOffset1, a.transform.rotation);
				child.transform.localScale = new Vector3 (child.transform.localScale.x, child.transform.localScale.y, 12);
				child = Instantiate (DoorStop, a.transform.position + xpOffset2, a.transform.rotation);
				child.transform.localScale = new Vector3 (child.transform.localScale.x, child.transform.localScale.y, 12);
			}
			if (Physics.OverlapSphere (a.xMinus.transform.position, 5).Length < 1) {
				GameObject child = Instantiate (DoorStop, a.transform.position + xmOffset1, a.transform.rotation);
				child.transform.localScale = new Vector3 (child.transform.localScale.x, child.transform.localScale.y, 12);
				child = Instantiate (DoorStop, a.transform.position + xmOffset2, a.transform.rotation);
				child.transform.localScale = new Vector3 (child.transform.localScale.x, child.transform.localScale.y, 12);
			}
			if (Physics.OverlapSphere (a.zPlus.transform.position, 5).Length < 1) {
				GameObject child = Instantiate (DoorStop, a.transform.position + zpOffset1, a.transform.rotation);
				child.transform.localScale = new Vector3 (12, child.transform.localScale.y, child.transform.localScale.z);
				child = Instantiate (DoorStop, a.transform.position + zpOffset2, a.transform.rotation);
				child.transform.localScale = new Vector3 (12, child.transform.localScale.y, child.transform.localScale.z);
			}
			if (Physics.OverlapSphere (a.zMinus.transform.position, 5).Length < 1) {
				GameObject child = Instantiate (DoorStop, a.transform.position + zmOffset1, a.transform.rotation);
				child.transform.localScale = new Vector3 (12, child.transform.localScale.y, child.transform.localScale.z);
				child = Instantiate (DoorStop, a.transform.position + zmOffset2, a.transform.rotation);
				child.transform.localScale = new Vector3 (12, child.transform.localScale.y, child.transform.localScale.z);
			}
		}
	}
}
