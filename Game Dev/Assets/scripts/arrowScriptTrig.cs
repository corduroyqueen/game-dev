using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScriptTrig : MonoBehaviour {

	public GameObject arrowPrefab;
	public float xDistanceFromParent;
	public float yDistanceFromParent;
	public float rotation;

	float increment;
	bool readyFire;

	// Use this for initialization
	void Start () {
		readyFire = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (readyFire == false) {
			increment++;
		}
		if (increment >= 100) {
			readyFire = true;
			increment = 0f;
		}
		
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.name == "player" && readyFire == true) {
			(Instantiate (arrowPrefab, new Vector2(transform.position.x + xDistanceFromParent,transform.position.y + yDistanceFromParent), new Quaternion (0f, 0f, rotation, 0f)) as GameObject).transform.parent = this.transform;
			readyFire = false;
		}
	}
}
