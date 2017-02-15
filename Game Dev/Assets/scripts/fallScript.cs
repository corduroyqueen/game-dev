using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallScript : MonoBehaviour {


	public GameObject player;
	private movementScript movementScript;



	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerStay2D (Collider2D other){



		if (other.gameObject.name == "fall Box" && movementScript.dashCheck == false) {
			movementScript.playerStatus = false;
		}
	}
}
