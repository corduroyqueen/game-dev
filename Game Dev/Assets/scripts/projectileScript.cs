using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	public GameObject player;
	private movementScript movementScript;

	float increment;
	public float increment2;

	public int direction;

	float okay;

	bool hitTrue;
	bool flying;

	Rigidbody2D arrowrb;

	public GameObject blood;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));

		increment = 0f;
		increment2 = 0f;

		arrowrb = GetComponent<Rigidbody2D> ();

		okay = Random.Range(0f,10f);

		flying = true;

		hitTrue = false;
	}
	
	// Update is called once per frame
	void Update () {

		Fire (direction);

		if (hitTrue == true) {

			increment2++;
			movementScript.ArrowHit();
		}
		if (increment2 >= 10f){
			movementScript.playerStatus = false;
			hitTrue = false;
			increment2 = 0f;

		}

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

			hitTrue = true;
			Instantiate (blood, new Vector2 (player.transform.position.x,player.transform.position.y),new Quaternion(0f,0f,0f,0f));
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
