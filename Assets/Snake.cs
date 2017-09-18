using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class Snake : MonoBehaviour {
	//By default the snake moves to right
	public float currentRotation;
	public float tailRotation;
	public List<Transform> tail = new List<Transform> ();
	public GameObject t;
	bool ate = false;
	bool rotated = false;
	public GameObject TailPrefab;
	public GameObject tPrefab;
	public Vector2 curdir = Vector2.right;
	public Vector2 taildir = Vector2.left;

//	private int level = 1;
	private bool exit = false;
	// Use this for initialization
	void Start () {
		t = (GameObject)Instantiate (tPrefab, new Vector2(transform.position.x-1, transform.position.y), Quaternion.identity);
		InvokeRepeating ("Move", 0.3f, 0.3f);
	}

	// Update is called once per frame
	void Update () {
		if (exit) {
			return;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (curdir == Vector2.up) {
				currentRotation += -90.0f;
				curdir = Vector2.right;
			} else if (curdir == -Vector2.up) {
				currentRotation += 90.0f;
				curdir = Vector2.right;
			} else {
				currentRotation += 0.0f;
			}
			rotated = true;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			if (curdir == -Vector2.right) {
				currentRotation += 90.0f;
				curdir = -Vector2.up;
			} else if (curdir == Vector2.right) {
				currentRotation += -90.0f;
				curdir = -Vector2.up;
			}else {
				currentRotation += 0.0f;
			}
			rotated = true;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			if (curdir == Vector2.up) {
				currentRotation += 90.0f;
				curdir = -Vector2.right;
			} else if (curdir == -Vector2.up) {
				currentRotation += -90.0f;
				curdir = -Vector2.right;
			}else {
				currentRotation += 0.0f;
			}
			rotated = true;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			if (curdir == -Vector2.right) {
				currentRotation += -90.0f;
				curdir = Vector2.up;
			} else if (curdir == Vector2.right) {
				currentRotation += 90.0f;
				curdir = Vector2.up;
			}else {
				currentRotation += 0.0f;
			}
			rotated = true;
		}
	}

	void calculateDir(Vector2 lastpos, Vector2 curpos){
		if (curpos.x - lastpos.x == 1) {//Heading Right
			if (taildir == Vector2.up) {
				tailRotation += 90.0f;
			} else if (taildir == Vector2.down) {
				tailRotation += -90.0f;
			} else {
				tailRotation += 0.0f;
			}
			taildir = Vector2.left;
		} else if (curpos.x - lastpos.x == -1) {//Heading Left
			if (taildir == Vector2.up) {
				tailRotation += -90.0f;
			} else if (taildir == Vector2.down) {
				tailRotation += 90.0f;
			} else {
				tailRotation += 0.0f;
			}
			taildir = Vector2.right;
		} else if (curpos.y - lastpos.y == 1) {//Heading Up
			if (taildir == Vector2.right) {
				tailRotation += -90.0f;
			} else if (taildir == Vector2.left) {
				tailRotation += 90.0f;
			} else {
				tailRotation += 0.0f;
			}
			taildir = Vector2.down;
		} else if (curpos.y - lastpos.y == -1) {
			if (taildir == Vector2.right) {
				tailRotation += 90.0f;
			} else if (taildir == Vector2.left) {
				tailRotation += -90.0f;
			} else {
				tailRotation += 0.0f;
			}
			taildir = Vector2.up;
		}
	}

	void Move(){
		if (exit) {
			return;
		}
		Vector2 v = transform.position;
		if (ate) {
			GameObject g = (GameObject)Instantiate (TailPrefab, v, Quaternion.identity);
			tail.Insert (0, g.transform);
			//if (tail.Count == 1) {
				//tailRotation = 0.0f;
			//}
			ate = false;
		} else if (tail.Count > 0) {
			Vector2 lastpos = tail.Last ().position;
			tail.Last ().position = v;
			tail.Insert (0, tail.Last ());
			tail.RemoveAt (tail.Count - 1);
			t.transform.position = lastpos;
			Vector2 curpos = tail.Last ().position;
			calculateDir (lastpos, curpos);
			t.transform.rotation = Quaternion.Euler(new Vector3(tPrefab.transform.rotation.x, tPrefab.transform.rotation.y, tailRotation));
		} else if (tail.Count == 0) {
			t.transform.position = v;
		}

		if (curdir == Vector2.right) {
			transform.position = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
		} else if (curdir == Vector2.up) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
		} else if (curdir == -Vector2.right) {
			transform.position = new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z);
		} else if (curdir == -Vector2.up) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z);
		}

		if (rotated == true) {
			transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
			if (tail.Count == 0) {
				//tailRotation += currentRotation;
				taildir = curdir;
				t.transform.rotation = Quaternion.Euler(new Vector3(tPrefab.transform.rotation.x, tPrefab.transform.rotation.y, currentRotation));
				tailRotation = currentRotation;
			}
			rotated = false;
		}
	}

//	void SnakeDisappear(){
//		while (tail.Count > 0) {
//			Debug.Log ("tailCount" + tail.Count);
//			removeBody ();
//		}
//		if (tail.Count == 0) {
//			Destroy (tPrefab);
//		}
//
//	}
//
//	void removeBody(){
//		Debug.Log ("removeCalled" + tail);
//		tail.RemoveAt (0);
//	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name.StartsWith ("FoodPrefab")) {
			ate = true;
			Destroy (coll.gameObject);
		}else if (coll.name.StartsWith ("exit")) {
			exit = true;
//			Debug.Log ("tail" + tail.Count);
			while (tail.Count > 0) {
				tail.RemoveAt (tail.Count - 1);
//				Invoke ("removeBody", 0.3f);
				Debug.Log ("tail" + tail.Count);
			}
			EditorUtility.DisplayDialog ("Congrats", "Going to next level", "OK");
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		} else {
			EditorUtility.DisplayDialog ("Oops", "Don't hit the wall", "OK");
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}
	}		
}