using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
	public GameObject root;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			root.SetActive (!root.activeSelf);
		}
	}

	public void StartGame(){
		SceneManager.LoadScene ("level1");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void Resume(){
		root.SetActive (false);
	}

	public void ReturntoMenu(){
		SceneManager.LoadScene ("Title");
	}

}
