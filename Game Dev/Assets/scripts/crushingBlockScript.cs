using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crushingBlockScript : MonoBehaviour {

	public float increment;
	Vector3 startPos;
	Rigidbody2D rb;

	public float direct1;
	public float direct2;
	public float speedx;
	public float speedy;

	public bool playerCheck;
	public bool wallCheck;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startPos = transform.position;

		playerCheck = false;
		wallCheck = false;

	}

	// Update is called once per frame
	void Update () {

		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		if (playerCheck == true && wallCheck == true) {

			movementScript.playerStatus = false;

		}
	}

	void FixedUpdate(){

		increment++;

		if (increment >= 1f && increment <= direct1) {
			rb.velocity = new Vector3 (-speedx, -speedy, 0f);
		}

		if (increment >= (direct1 + 1f) && increment <= (direct1 + direct2)) {
			rb.velocity = new Vector3 (speedx, speedy, 0f);
		}
			
		if (increment >= (direct1 + direct2 + 1f)) {
			transform.position = startPos;
			increment = 0f;
		}

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "wall") {

			wallCheck = true;

		}

		if (other.gameObject.name == "player") {

			playerCheck = true;

		}

	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "wall") {

			wallCheck = false;

		}

		if (other.gameObject.name == "player") {

			playerCheck = false;

		}
	}


}
