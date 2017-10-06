using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour {
	public GameObject stone;
	public GameObject big_tree;
	public GameObject small_tree;
	//public GameObject sto;
	//public GameObject bt;
	public GameObject m;
	public GameObject bg;

	// Use this for initialization
	void Start () {
		//GameObject bkground = (GameObject)Instantiate (bg, new Vector3(-356, 0, 20), Quaternion.identity);
		GameObject sto = (GameObject)Instantiate (stone, new Vector2(-854, 345), Quaternion.identity);
		sto = (GameObject)Instantiate (stone, new Vector2(-811, 310), Quaternion.identity);
		sto = (GameObject)Instantiate (stone, new Vector2(-752, 351), Quaternion.identity);
		sto = (GameObject)Instantiate (stone, new Vector2(39, 10), Quaternion.identity);
		sto = (GameObject)Instantiate (stone, new Vector2(-793, -486), Quaternion.identity);
		sto = (GameObject)Instantiate (stone, new Vector2(-713, -501), Quaternion.identity);
		sto = (GameObject)Instantiate (stone, new Vector2(-793, -486), Quaternion.identity);
		sto = (GameObject)Instantiate (stone, new Vector2(-702, -459), Quaternion.identity);
		GameObject bt = (GameObject)Instantiate (big_tree, new Vector2(-133, 103), Quaternion.identity);
		GameObject monk = (GameObject)Instantiate (m, new Vector2(-193, -14), Quaternion.identity);
		GameObject st = (GameObject)Instantiate (small_tree, new Vector2(-630, -405), Quaternion.identity);
		st = (GameObject)Instantiate (small_tree, new Vector2(-701, -413), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
