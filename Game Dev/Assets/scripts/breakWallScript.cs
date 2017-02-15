using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakWallScript : MonoBehaviour {

	public GameObject bagSize;
	private bagSizeScript bagSizeScript;
	public GameObject player;
	private movementScript movementScript;

	public float sizeReq;

	// Use this for initialization
	void Start () {

		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));


	}
	
	// Update is called once per frame
	void Update () {



	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.name == "player") {
			if (movementScript.hittingCheck == true && bagSizeScript.size == sizeReq)
				Destroy (this.gameObject);
		}
	}
}
