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
	public int tier;
	public int roomRadius;
	public int minRoomRadius;

	public GameObject[] plainsEnemies;
	public GameObject[] ruinsEnemies;
	public GameObject[] caveEnemies;
	public GameObject[] dungeonEnemies;

	public GameObject PauseMenu;
	public GameObject wbox;
	public GameObject abox;
	// Use this for initialization
	void Start () {
		if (count == roomRadius) {
			if (GameObject.FindGameObjectsWithTag ("Boss").Length == 0) {
				int bossTheme = 2;
				if (name == "RoomCave") {
					bossTheme = 0;
				}
				if (name == "RoomDungeon") {
					bossTheme = 1;
				}
				if (name == "RoomPlains") {
					bossTheme = 2;
				}
				if (name == "RoomRuins") {
					bossTheme = 3;
				}

				GameObject Boss = GameObject.Find ("Controller").GetComponent<Enemy> ().bosses [bossTheme];
				GameObject child = Instantiate (Boss, transform.position + new Vector3 (0, Boss.transform.position.y, 0), Quaternion.identity);
				child.GetComponent<EnemyController> ().tier = tier;
				child.GetComponent<EnemyController> ().defence *= tier;
				child.GetComponent<EnemyController> ().damage *= tier;
				child.GetComponent<EnemyController> ().health *= tier;
				child.name = Boss.name;
			} else {
				newFloor ();
			}

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
					child.GetComponent<LayoutGen> ().tier = tier;
					child.name = name;
					SetRoomType (child);
				}
			}
			if (xmConnection == 1) {
				if (Physics.OverlapSphere (xMinus.transform.position, 5).Length == 0) {
					GameObject child = Instantiate (Room, xMinus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
					child.GetComponent<LayoutGen> ().tier = tier;
					child.name = name;
					SetRoomType (child);
				}
			}
			if (zpConnection == 1) {
				if (Physics.OverlapSphere (zPlus.transform.position, 5).Length == 0) {
					GameObject child = Instantiate (Room, zPlus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
					child.GetComponent<LayoutGen> ().tier = tier;
					child.name = name;
					SetRoomType (child);
				}
			}
			if (zmConnection == 1) {
				if (Physics.OverlapSphere (zMinus.transform.position, 5).Length == 0) {
					GameObject child = Instantiate (Room, zMinus.transform.position, Quaternion.identity);
					child.GetComponent<LayoutGen> ().count++;
					child.GetComponent<LayoutGen> ().tier = tier;
					child.name = name;
					SetRoomType (child);
				}
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
	}

	void newFloor(){
		GameObject child = Instantiate (teleporter, this.gameObject.transform.position + new Vector3(0,3,0), Quaternion.identity);
		if (name == "RoomCave") {
			child.GetComponentInChildren<Teleporter> ().SourceRoomTheme = 0;
		}
		if (name == "RoomDungeon") {
			child.GetComponentInChildren<Teleporter> ().SourceRoomTheme = 1;
		}
		if (name == "RoomPlains") {
			child.GetComponentInChildren<Teleporter> ().SourceRoomTheme = 2;
		}
		if (name == "RoomRuins") {
			child.GetComponentInChildren<Teleporter> ().SourceRoomTheme = 3;
		}
		child.GetComponentInChildren<Teleporter> ().tier = tier;

	}

	void SetRoomType(GameObject room){
		int t = Random.Range (1, 20);
		if (t > 7) {
			//if (room.GetComponent<RoomType> () != null) {
			room.AddComponent<RoomType> ();
			room.GetComponent<RoomType> ().roomType = "Enemy";
			GameObject[] enemyList;
			enemyList = GameObject.Find ("Controller").GetComponent<Enemy> ().dungeonEnemies;
			if (room.name == "RoomPlains") {
				enemyList = GameObject.Find ("Controller").GetComponent<Enemy> ().plainsEnemies;
			}
			if (room.name == "RoomCave") {
				enemyList = GameObject.Find ("Controller").GetComponent<Enemy> ().caveEnemies;
			}
			if (room.name == "RoomRuins") {
				enemyList = GameObject.Find ("Controller").GetComponent<Enemy> ().ruinsEnemies;
			}
			if (room.name == "RoomDungeon") {
				enemyList = GameObject.Find ("Controller").GetComponent<Enemy> ().dungeonEnemies;
			}
			int j = Random.Range (1, 4);
			for (int i = 0; i < j; i++) {
				int k = Random.Range (0, enemyList.Length);
				GameObject child = Instantiate (enemyList [k], room.transform.position + new Vector3 (Random.Range (-12, 12), enemyList [k].transform.position.y, Random.Range (-12, 12)), Quaternion.identity);
				child.GetComponent<EnemyController> ().defence *= room.GetComponent<LayoutGen> ().tier;
				child.GetComponent<EnemyController> ().damage *= room.GetComponent<LayoutGen> ().tier;
				child.GetComponent<EnemyController> ().health *= room.GetComponent<LayoutGen> ().tier;
				child.GetComponent<EnemyController> ().tier = room.GetComponent<LayoutGen> ().tier;
				child.name = enemyList [k].name;
			}
			//}
		} else if (t == 1 || t == 2) {
			GameObject child = Instantiate (wbox, room.transform.position + new Vector3 (0, wbox.transform.position.y, 0), Quaternion.identity);
			child.GetComponent<LootBox> ().tier = tier - 1;
		} else if (t == 3 || t == 4) {
			GameObject child = Instantiate (abox, room.transform.position + new Vector3 (0, abox.transform.position.y, 0), Quaternion.identity);
			child.GetComponent<LootBox> ().tier = tier - 1;
		}
	}
}
