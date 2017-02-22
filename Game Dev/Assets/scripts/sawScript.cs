using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawScript : MonoBehaviour {

	public float increment;
	Vector3 startPos;
	Rigidbody2D rb;

	public float direct1;
	public float direct2;
	public float speedx;
	public float speedy;

	public GameObject player;
	private movementScript movementScript;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));
		movementScript = player.GetComponent<movementScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){


		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);

		increment++;

		if (increment >= 1f && increment <= direct1) {
			rb.velocity = new Vector3 (-speedx, -speedy, 0f);
		}

		if (increment >= (direct1 + 1f) && increment <= (direct1 + direct2)) {
			rb.velocity = new Vector3 (speedx, speedy, 0f);
		}

		if (increment >= (direct1 + direct2 + 1f)) {
			increment = 0f;
		}


	}

	void OnTriggerStay2D (Collider2D other)
	{

		if (other.gameObject.name == "player") {
			movementScript.playerStatus = false;
		}

	}
}
