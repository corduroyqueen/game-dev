using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMovement : MonoBehaviour {

	public float increment;
	Vector3 startPos;
	Rigidbody2D rb;

	public float direct1;
	public float direct2;
	public float direct3;
	public float direct4;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
	}

	void FixedUpdate(){

		increment++;

		if (increment >= 1f && increment <= direct1) {
			rb.velocity = new Vector3 (-speed, 0f, 0f);
		}

		if (increment >= (direct1 + 1f) && increment <= (direct1 + direct2)) {
			rb.velocity = new Vector3 (0f, -speed, 0f);
		}

		if (increment >= (direct1 + direct2 + 1) && increment <= (direct1 + direct2 + direct3)) {
			rb.velocity = new Vector3 (speed, 0f, 0f);
		}

		if (increment >= (direct1 + direct2 + direct3 + 1f) && increment <= (direct1 + direct2 + direct3 + direct4)) {
			rb.velocity = new Vector3 (0f, speed, 0f);
		}

		if (increment >= (direct1 + direct2 + direct3 + direct4 + 1f)) {
			transform.position = startPos;
			increment = 0f;
		}

	}
}
