using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGen : MonoBehaviour {
	public GameObject Room;
	public GameObject xPlus;
	public GameObject xMinus;
	public GameObject zPlus;
	public GameObject zMinus;
	public GameObject teleporter;
	public int xpConnection;
	public int xmConnection;
	public int zpConnection;
	public int zmConnection;
	public int count;
	public int roomRadius;
	public int minRoomRadius;

	public GameObject[] plainsEnemies;
	public GameObject[] ruinsEnemies;
	public GameObject[] caveEnemies;
	public GameObject[] dungeonEnemies;
	// Use this for initialization
	void Start () {
		if (count == roomRadius) {
			newFloor();
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
				if (Physics.OverlapSphere (xPlus.transform.position, 5).Length == 0) {
					GameObject child = Instantiate (Room, xPlus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
					child.name = name;
					child.AddComponent<Enemy> ();
					SetRoomType (child);
				}
			}
			if (xmConnection == 1) {
				if (Physics.OverlapSphere (xMinus.transform.position, 5).Length == 0) {
					GameObject child = Instantiate (Room, xMinus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
					child.name = name;
				}
			}
			if (zpConnection == 1) {
				if (Physics.OverlapSphere (zPlus.transform.position, 5).Length == 0) {
					GameObject child = Instantiate (Room, zPlus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
					child.name = name;
				}
			}
			if (zmConnection == 1) {
				if (Physics.OverlapSphere (zMinus.transform.position, 5).Length == 0) {
					GameObject child = Instantiate (Room, zMinus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
					child.name = name;
				}
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
	}

	void newFloor(){
		Instantiate (teleporter, this.gameObject.transform.position + new Vector3(0,3,0), Quaternion.identity);

	}

	void SetRoomType(GameObject room){
		if (Random.Range (1, 3) == 1) {
			room.AddComponent<Enemy> ();
			GameObject[] enemyList;
			//if (room.name == "RoomPlains") {
				enemyList = plainsEnemies;
			//}
			int j = Random.Range (1, 7);
			for (int i = 0; i < j; i++) {
				int k = Random.Range (0, enemyList.Length - 1);
				Instantiate (enemyList [k], room.transform.position + new Vector3 (Random.Range (-12, 12), enemyList[k].transform.position.y, Random.Range (-12, 12)),Quaternion.identity);
			}
		}
	}
}
