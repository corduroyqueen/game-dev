using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropoffScript : MonoBehaviour
{

	public float type;

	public GameObject player;
	public movementScript movementScript;

	public GameObject bagSize;
	private bagSizeScript bagSizeOtherScript;

	private bool full;

	public float contained;

	public float size;

	public bool fallCheck;

	bool once;
	bool keyStopper;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));
		movementScript = player.GetComponent<movementScript> ();

		bagSize = GameObject.Find ("bagSize");
		bagSizeOtherScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));
		bagSizeOtherScript = bagSize.GetComponent<bagSizeScript> ();

		size = bagSizeOtherScript.size;

		full = false;

		keyStopper = true;
		once = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (bagSizeOtherScript.size == 6f) {
			full = true;
		} else {
			full = false;
		}

		size = bagSizeOtherScript.size;

	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			keyStopper = false;
		}


		if (other.gameObject.name == "player" && keyStopper == false) {
			Run ();
			keyStopper = true;
		}

		if (Input.GetKeyUp (KeyCode.E)) {
			once = true;
		}


	}

	public void Run ()
	{

		if (type == 1f) {
			if (movementScript.numberOf1 >= 1 && once == true) {
				bagSizeOtherScript.size -= movementScript.numberOf1;
				contained += movementScript.numberOf1;
				movementScript.numberOf1 = 0f;
				once = false;
			}
			if (movementScript.numberOf1 == 0f && bagSizeOtherScript.size <= 5f && contained >= 1f && once == true) {
				if (size == 5f && contained >= 1f) {
					bagSizeOtherScript.Run (1f);
					contained -= 1f;
					movementScript.numberOf1 += 1f;
				}
					
				if (size == 4f && contained >= 2f) {
					bagSizeOtherScript.Run (2f);
					contained -= 2f;
					movementScript.numberOf1 += 2f;
				}
				if (size == 4f && contained == 1f) {
					bagSizeOtherScript.Run (1f);
					contained -= 1f;
					movementScript.numberOf1 += 1f;
				}
					
				if (size == 3f && contained >= 3f) {
					bagSizeOtherScript.Run (3f);
					contained -= 3f;
					movementScript.numberOf1 += 3f;
				}
				if (size == 3f && contained == 2f) {
					bagSizeOtherScript.Run (2f);
					contained -= 2f;
					movementScript.numberOf1 += 2f;
				}
				if (size == 3f && contained == 1f) {
					bagSizeOtherScript.Run (1f);
					contained -= 1f;
					movementScript.numberOf1 += 1f;
				}

				if (size == 2f && contained >= 4f) {
					bagSizeOtherScript.Run (4f);
					contained -= 4f;
					movementScript.numberOf1 += 4f;
				}
				if (size == 2f && contained == 3f) {
					bagSizeOtherScript.Run (3f);
					contained -= 3f;
					movementScript.numberOf1 += 3f;
				}

				if (size == 2f && contained == 2f) {
					bagSizeOtherScript.Run (2f);
					contained -= 2f;
					movementScript.numberOf1 += 2f;
				}

				if (size == 2f && contained == 1f) {
					bagSizeOtherScript.Run (1f);
					contained -= 1f;
					movementScript.numberOf1 += 1f;
				}

				if (size == 1f && contained >= 5f) {
					bagSizeOtherScript.Run (5f);
					contained -= 5f;
					movementScript.numberOf1 += 5f;
				}

				if (size == 1f && contained == 4f) {
					bagSizeOtherScript.Run (4f);
					contained -= 4f;
					movementScript.numberOf1 += 4f;
				}

				if (size == 1f && contained == 3f) {
					bagSizeOtherScript.Run (3f);
					contained -= 3f;
					movementScript.numberOf1 += 3f;
				}

				if (size == 1f && contained == 2f) {
					bagSizeOtherScript.Run (2f);
					contained -= 2f;
					movementScript.numberOf1 += 2f;
				}

				if (size == 1f && contained == 1f) {
					bagSizeOtherScript.Run (1f);
					contained -= 1f;
					movementScript.numberOf1 += 1f;
				}
					
				if (size == 0f && contained == 6f) {
					bagSizeOtherScript.Run (6f);
					contained -= 6f;
					movementScript.numberOf1 += 6f;
				}

				if (size == 0f && contained >= 5f) {
					bagSizeOtherScript.Run (5f);
					contained -= 5f;
					movementScript.numberOf1 += 5f;
				}

				if (size == 0f && contained == 4f) {
					Debug.Log ("hey");
					bagSizeOtherScript.Run (4f);
					contained -= 4f;
					movementScript.numberOf1 += 4f;
				}

				if (size == 0f && contained == 3f) {
					bagSizeOtherScript.Run (3f);
					contained -= 3f;
					movementScript.numberOf1 += 3f;
				}

				if (size == 0f && contained == 2f) {
					bagSizeOtherScript.Run (2f);
					contained -= 2f;
					movementScript.numberOf1 += 2f;
				}

				if (size == 0f && contained == 1f) {
					bagSizeOtherScript.Run (1f);
					contained -= 1f;
					movementScript.numberOf1 += 1f;
				}

				once = false;

			}
		}

		if (type == 2f) {
			if (movementScript.numberOf2 >= 1 && once == true) {
				bagSizeOtherScript.size -= movementScript.numberOf2 * 2f;
				contained += movementScript.numberOf2;
				movementScript.numberOf2 = 0f;
				once = false;
			}
			if (movementScript.numberOf2 == 0f && bagSizeOtherScript.size <= 4f && contained >= 1f && once == true) {

				if (size == 4f && contained >= 1f) {
					bagSizeOtherScript.Run (2f);
					contained -= 1f;
					movementScript.numberOf2 += 1f;
				}

				if (size == 3f && contained >= 1f) {
					bagSizeOtherScript.Run (2f);
					contained -= 1f;
					movementScript.numberOf2 += 1f;
				}

				if (size == 2f && contained >= 2f) {
					bagSizeOtherScript.Run (4f);
					contained -= 2f;
					movementScript.numberOf2 += 2f;
				}

				if (size == 2f && contained == 1f) {
					bagSizeOtherScript.Run (2f);
					contained -= 1f;
					movementScript.numberOf2 += 1f;
				}

				if (size == 1f && contained >= 2f) {
					bagSizeOtherScript.Run (4f);
					contained -= 2f;
					movementScript.numberOf2 += 2f;
				}

				if (size == 1f && contained == 1f) {
					bagSizeOtherScript.Run (2f);
					contained -= 1f;
					movementScript.numberOf2 += 1f;
				}


				if (size == 0f && contained >= 3f) {
					bagSizeOtherScript.Run (6f);
					contained -= 3f;
					movementScript.numberOf2 += 3f;
				}

				if (size == 0f && contained == 2f) {
					bagSizeOtherScript.Run (4f);
					contained -= 2f;
					movementScript.numberOf2 += 2f;
				}


				if (size == 0f && contained == 1f) {
					bagSizeOtherScript.Run (2f);
					contained -= 1f;
					movementScript.numberOf2 += 1f;
				}

				once = false;

			}


		}

		if (type == 3f) {
			if (movementScript.numberOf3 >= 1 && once == true) {
				bagSizeOtherScript.size -= movementScript.numberOf3 * 3f;
				contained += movementScript.numberOf3;
				movementScript.numberOf3 = 0f;
				once = false;
			}
			if (movementScript.numberOf3 == 0f && bagSizeOtherScript.size <= 3f && contained >= 1f && once == true) {

				if (size >= 1f && contained >= 1f) {
					bagSizeOtherScript.Run (3f);
					contained -= 1f;
					movementScript.numberOf3 += 1f;
				}
				
				if (size == 0f && contained >= 2f) {
					bagSizeOtherScript.Run (6f);
					contained -= 2f;
					movementScript.numberOf3 += 2f;
				}
				if (size == 0f && contained == 1f) {
					bagSizeOtherScript.Run (3f);
					contained -= 1f;
					movementScript.numberOf3 += 1f;
				}

				once = false;

			}
		}
		
		if (type == 4f) {
			if (movementScript.numberOf4 >= 1 && once == true) {
				bagSizeOtherScript.size -= movementScript.numberOf4 * 4f;
				contained += movementScript.numberOf4;
				movementScript.numberOf4 = 0f;
				once = false;
			}
			if (movementScript.numberOf4 == 0f && bagSizeOtherScript.size <= 2f && contained >= 1f && once == true) {
				if (size <= 2f && contained >= 1f) {
					bagSizeOtherScript.Run (4f);
					contained -= 1;
					movementScript.numberOf4 += 1f;
					once = false;
				}

			}
		}

		if (type == 5f) {
			if (movementScript.numberOf5 >= 1 && once == true) {
				bagSizeOtherScript.size -= movementScript.numberOf5 * 5f;
				contained += movementScript.numberOf5;
				movementScript.numberOf5 = 0f;
				once = false;
			}
			if (movementScript.numberOf5 == 0f && bagSizeOtherScript.size <= 1f && contained >= 1f && once == true) {
				if (size <= 1f && contained >= 1f) {
					bagSizeOtherScript.Run (5f);
					contained -= 1;
					movementScript.numberOf5 += 1f;
					once = false;
				}

			}
		}

		if (type == 6f) {
			if (movementScript.numberOf6 >= 1 && once == true) {
				bagSizeOtherScript.size -= movementScript.numberOf6 * 6f;
				contained += movementScript.numberOf6;
				movementScript.numberOf6 = 0f;
				once = false;
			}
			if (movementScript.numberOf6 == 0f && bagSizeOtherScript.size == 0f && contained >= 1f && once == true) {
				if (size == 0f && contained >= 1f) {
					bagSizeOtherScript.Run (6f);
					contained -= 1;
					movementScript.numberOf6 += 1f;
					once = false;
				}

			}
		}
	}
}