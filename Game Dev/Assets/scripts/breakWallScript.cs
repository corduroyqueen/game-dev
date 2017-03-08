using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakWallScript : MonoBehaviour {

	public GameObject bagSize;
	private bagSizeScript bagSizeScript;
	public GameObject player;
	private movementScript movementScript;

	public GameObject breakParticles;

	public float sizeReq;

	public bool collision;

	// Use this for initialization
	void Start () {

		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));

		collision = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (movementScript.hittingCheck == true && bagSizeScript.size == sizeReq && collision == true) {
			Instantiate (breakParticles, new Vector2 (this.transform.position.x,this.transform.position.y),new Quaternion(0f,0f,0f,0f));
			Destroy (this.gameObject);
		}

	}

	void OnTriggerStay2D (Collider2D other)
	{
	}

	void OnCollisionStay2D (Collision2D other){

		if (other.gameObject.name == "bagSize") {

			collision = true;

		} else {
			collision = false;
		}
	}
}
