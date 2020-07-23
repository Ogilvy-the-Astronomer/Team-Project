using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndCrystal : MonoBehaviour {
	public GameObject child;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		child.transform.Rotate (0, 1, 0);
	}

	public void Endgame(){
		SceneManager.LoadScene ("End");
	}
}
