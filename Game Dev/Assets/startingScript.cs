using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingScript : MonoBehaviour {

	public GameObject screen1;
	public GameObject screen2;
	public float alpha;
	public bool intro;
	public bool ready;
	public bool transition;

	public float timer;

	// Use this for initialization
	void Start () {

		alpha = 1f;

		intro = true;
		ready = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (screen1.GetComponent<SpriteRenderer> ().enabled == true && Input.GetKeyDown (KeyCode.E)) {
			
			ready = false;
		}

		if (screen1.GetComponent<SpriteRenderer> ().enabled == true && Input.GetKeyUp (KeyCode.E)) {
			screen1.GetComponent<SpriteRenderer> ().enabled = false;
			screen2.GetComponent<SpriteRenderer> ().enabled = true;
			ready = true;
		}

		if (ready == true) {
			timer++;

		}




		if (screen2.GetComponent<SpriteRenderer> ().enabled == true && Input.GetKeyDown (KeyCode.E) && timer >= 10f) {

			transition = true;


		}

		if (transition = true) {

			alpha -= 0.005f;

			screen2.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, alpha);

			if (alpha <= 0f) {

				transition = false;
				intro = false;

			}

		}

	}
}
 