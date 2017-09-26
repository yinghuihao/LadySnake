using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
	private float cloud_speed = 100.0f;
	// Use this for initialization1234
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * Time.deltaTime * cloud_speed);
		if (transform.position.x <= -2116f) {
			transform.position = new Vector2 (2000f, transform.position.y);
		}
	}
}
