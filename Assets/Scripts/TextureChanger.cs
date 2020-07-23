using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChanger : MonoBehaviour {
	public Texture[] altTextures;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.SetTexture("_MainTex",altTextures[transform.root.GetComponent<EnemyController>().tier - 1]);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
