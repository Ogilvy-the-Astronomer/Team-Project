using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGen : MonoBehaviour {
	public GameObject Room;
	public GameObject xPlus;
	public GameObject xMinus;
	public GameObject zPlus;
	public GameObject zMinus;
	public Material[] textures;
	public int xpConnection;
	public int xmConnection;
	public int zpConnection;
	public int zmConnection;
	public int count;
	public int roomRadius;
	public int minRoomRadius;
	// Use this for initialization
	void Start () {
		int textureNo = Random.Range (0, 4);
		GetComponent<Renderer> ().material = textures [textureNo];
		if (count == roomRadius) {
			GetComponent<Renderer> ().material = textures [4];

		}
		if (count < roomRadius) {
			xpConnection = Random.Range (0, 2);
			xmConnection = Random.Range (0, 2);
			zpConnection = Random.Range (0, 2);
			zmConnection = Random.Range (0, 2);
			if (count < minRoomRadius) {
				xpConnection = xmConnection = zmConnection = zpConnection = 1;
			}
			if (xpConnection == 1) {
				if (Physics.OverlapSphere (xPlus.transform.position, 5).Length < 1) {
					GameObject child = Instantiate (Room, xPlus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
				}
			}
			if (xmConnection == 1) {
				if (Physics.OverlapSphere (xMinus.transform.position, 5).Length < 1) {
					GameObject child = Instantiate (Room, xMinus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
				}
			}
			if (zpConnection == 1) {
				if (Physics.OverlapSphere (zPlus.transform.position, 5).Length < 1) {
					GameObject child = Instantiate (Room, zPlus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
				}
			}
			if (zmConnection == 1) {
				if (Physics.OverlapSphere (zMinus.transform.position, 5).Length < 1) {
					GameObject child = Instantiate (Room, zMinus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
				}
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
	}
}
