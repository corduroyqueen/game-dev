using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBlockScript : MonoBehaviour {

	public GameObject bagSize;
	private bagSizeScript bagSizeScript;
	public GameObject player;
	private movementScript movementScript;

	public float sizeReq;

	Rigidbody2D rb;

	public float increment;
	public float incrementStartingValue;
	public float incrementRateofChange;
	public bool traveling;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));

	}

	// Update is called once per frame
	void Update () {



		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
	}

	void FixedUpdate(){


		if (traveling == true && increment >= 0f) {
			increment -= incrementRateofChange;
			rb.velocity = new Vector3 (-increment, 0f, 0f);
		}

		if (increment <= 0f) {
			increment = 0f;
			traveling = false;
			rb.velocity = new Vector3 (0f, 0f, 0f);
		}

	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.name == "player") {
			if (movementScript.hittingCheck == true && bagSizeScript.size == sizeReq && traveling == false) {
				increment = incrementStartingValue;
				traveling = true;
			}
		}
	}
}
