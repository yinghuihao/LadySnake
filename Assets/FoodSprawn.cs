﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSprawn : MonoBehaviour {
	//Borders
	public Transform border_top;
	public Transform border_bottom;
	public Transform border_left;
	public Transform border_right;

	//Food Prefab
	public GameObject food;

	//Spawn a piece of food randomly within borders
	void randomSpawn(){
		int x = (int)Random.Range (border_left.position.x, border_right.position.x);
		int y = (int)Random.Range (border_bottom.position.y, border_top.position.y);
		Instantiate (food, new Vector2(x, y), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("randomSpawn", 3, 4);
	}
}
