using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour {
	
	public GameObject player;
	private movementScript movementScript;
	public float number;


	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));

	}
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.name == "player")
			movementScript.checkpointNum = number;
	}
			
}
