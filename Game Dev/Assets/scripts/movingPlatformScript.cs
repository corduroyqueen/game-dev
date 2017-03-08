using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformScript : MonoBehaviour {

	public float increment;
	public Vector3 startPos;
	Rigidbody2D rb;

	public float direct1;
	public float direct2;
	public float direct3;
	public float direct4;
	public float speed;

	public static bool movementCheck;

	public static bool fallCheck;

	public GameObject player;
	private movementScript movementScript; 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startPos = transform.position;

		fallCheck = true;

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));
		movementScript = player.GetComponent<movementScript> ();

		movementCheck = false;
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
			increment = 0f;
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "fall Box") {

			fallCheck = false;

		}



	}


	void OnTriggerStay2D (Collider2D other){

		movementCheck = true;

		if (other.gameObject.name == "fall Box" && movementCheck == true) {

			if (increment >= 1f && increment <= direct1) {
				movementScript.playerrb.velocity = new Vector3 (-speed, 0f, 0f);
			}

			if (increment >= (direct1 + 1f) && increment <= (direct1 + direct2)) {
				movementScript.playerrb.velocity = new Vector3 (0f, -speed, 0f);
			}

			if (increment >= (direct1 + direct2 + 1) && increment <= (direct1 + direct2 + direct3)) {
				movementScript.playerrb.velocity = new Vector3 (speed, 0f, 0f);
			}

			if (increment >= (direct1 + direct2 + direct3 + 1f) && increment <= (direct1 + direct2 + direct3 + direct4)) {
				movementScript.playerrb.velocity = new Vector3 (0f, speed, 0f);
			}

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "fall Box") {

			fallCheck = true;
			movementCheck = false;
		}

	}
}
