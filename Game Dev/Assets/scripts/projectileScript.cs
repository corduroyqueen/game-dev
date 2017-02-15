using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	public GameObject player;
	private movementScript movementScript;

	float increment;

	public int direction;

	float okay;

	bool flying;

	Rigidbody2D arrowrb;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));

		increment = 0f;

		arrowrb = GetComponent<Rigidbody2D> ();

		okay = Random.Range(0f,10f);

		flying = true;



	}
	
	// Update is called once per frame
	void Update () {

		Fire (direction);

	}

	void Fire(int direction){

		if (direction == 1 && flying == true){
			arrowrb.AddForce(new Vector3(-1f,0f,0f),ForceMode2D.Impulse);
		}
		if (direction == 2 && flying == true){
			arrowrb.AddForce(new Vector3(0f,1f,0f),ForceMode2D.Impulse);
		}

		if (direction == 3 && flying == true){
			arrowrb.AddForce(new Vector3(1f,0f,0f),ForceMode2D.Impulse);
		}

		if (direction == 4 && flying == true){
			arrowrb.AddForce(new Vector3(0f,-1f,0f),ForceMode2D.Impulse);
		}
	}

	public void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.name == "player" && flying == true) {
			movementScript.playerStatus = false;
		}

		if (other.gameObject.tag == "wall") {
			flying = false;
			arrowrb.velocity = new Vector3 (0f, 0f, 0f);
		}
	}

	public void OnTriggerStay2D (Collider2D other){



		if (other.gameObject.tag == "wall") {
			increment++;
		}
			

		if (increment >= 10f + okay) {
			Destroy (this.gameObject);
			increment = 0f;
		}
	}
}
