using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingScript : MonoBehaviour {

	public GameObject screen1;
	public GameObject screen2;
	public float alpha;
	public bool intro;
	public bool screen1check;
	public bool screen2check;
	public bool transition;
	public bool ready;

	public float timer;

	// Use this for initialization
	void Start () {

		alpha = 1f;

		intro = true;
		screen1check = true;
		screen2check = false;
		ready = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (screen1check == true) {

			screen1.GetComponent<SpriteRenderer> ().enabled = true;
			screen2.GetComponent<SpriteRenderer> ().enabled = false;
			screen2check = false;
		}

		if (screen1check == true && Input.GetKeyDown (KeyCode.E)) {
			screen1check = false;
			screen2check = true;
		}

		if (screen2check == true) {

			screen1.GetComponent<SpriteRenderer> ().enabled = false;
			screen2.GetComponent<SpriteRenderer> ().enabled = true;
			screen1check = false;
		}

		if (screen2check == true && Input.GetKeyUp (KeyCode.E) && ready == false) {

			ready = true;
			timer++;

		}




		if (screen2check == true && Input.GetKeyDown (KeyCode.E) && ready == true) {

			transition = true;
			timer++;

		}

		if (transition = true && screen2.GetComponent<SpriteRenderer> ().enabled == true && ready == true && timer >= 2f) {

			alpha -= 0.005f;

			screen2.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, alpha);

			if (alpha <= 0f) {

				transition = false;
				intro = false;

			}

		}

	}
}
 