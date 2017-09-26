using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkRefresh : MonoBehaviour {
	public Transform border_top;
	public Transform border_bottom;
	public Transform border_left;
	public Transform border_right;

	public GameObject monk;

	void randomMonk(){
		int x = (int)Random.Range (border_left.position.x, border_right.position.x);
		int y = (int)Random.Range (border_bottom.position.y, border_top.position.y);
		Instantiate (monk, new Vector2(x, y), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("randomMonk", 5, 5);
	}
}
