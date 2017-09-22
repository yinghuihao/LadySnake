﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkAttack : MonoBehaviour {
	public float timeBetweenAttacks = 0.5f;
	public float attackDamage = 10.0f;
	//public Snake player;
	public GameObject player;
	bool playerInRange;
	float timer;

	void OnTriggerStay2D(Collider2D other){
		if (other.name.StartsWith ("Snake")) {
			playerInRange = true;
			player.SendMessage ("TakeDamage", attackDamage*Time.deltaTime);
			//Debug.Log ("In range");
		} else if(other.name.StartsWith("TailPrefab")){
			player.SendMessage ("TakeDamage", attackDamage*Time.deltaTime);
			Debug.Log (other.name);
		}
	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Snake");
	}
}