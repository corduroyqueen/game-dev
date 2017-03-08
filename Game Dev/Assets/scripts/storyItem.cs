using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyItem : MonoBehaviour {

	public GameObject player;
	private movementScript movementScript; 

	public bool collect;
	public bool viewing;
	public bool exit;

	public int item;

	public GameObject item1;
	public GameObject item2;
	public GameObject item3;

	// Use this for initialization
	void Start () {

		collect = false;
		viewing = false;
		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));
		movementScript = player.GetComponent<movementScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (collect == true && Input.GetKeyUp (KeyCode.E)) {
			viewing = true;
		}
			

		if (viewing == true) {
			movementScript.ArrowHit ();

			if (item == 1) {
				item1.GetComponent<SpriteRenderer> ().enabled = true;
			}

			if (item == 2) {
				item2.GetComponent<SpriteRenderer> ().enabled = true;
			}

			if (item == 3) {
				item3.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}

		if (viewing == true && Input.GetKeyDown (KeyCode.E)) {

			item1.GetComponent<SpriteRenderer> ().enabled = false;
			item2.GetComponent<SpriteRenderer> ().enabled = false;
			item3.GetComponent<SpriteRenderer> ().enabled = false;
			viewing = false;
			movementScript.arrowDying = false;
			collect = false;
		}

	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "player") {
			collect = true;
		}
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		collect = false;
	}
}
