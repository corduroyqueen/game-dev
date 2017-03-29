 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bagSizeScript : MonoBehaviour {

	public GameObject player;
	private movementScript movementScript;

	private bool runCheck = false;
	public float size = 0f;

	public GameObject trail;

	Vector2 location;

	public Sprite size0;
	public Sprite size1;
	public Sprite size2;
	public Sprite size3;
	public Sprite size4;
	public Sprite size5;
	public Sprite size6;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);

		if (runCheck == true) {
			runCheck = false;
		}

		if (size == 0f) {
			transform.localScale = new Vector3 (0.85f, 0.85f, 1.41432f);
			GetComponent<SpriteRenderer> ().sprite = size0;
		}

		if (size == 1f) {
			transform.localScale = new Vector3 (1f, 1f, 1.41432f);
			GetComponent<SpriteRenderer> ().sprite = size1;
		}

		if (size == 2f) {
			transform.localScale = new Vector3 (1.15f, 1.15f, 1.41432f);
			GetComponent<SpriteRenderer> ().sprite = size2;
		}

		if (size == 3f) {
			transform.localScale = new Vector3 (1.30f, 1.30f, 1.41432f);
			GetComponent<SpriteRenderer> ().sprite = size3;
		}

		if (size == 4f) {
			transform.localScale = new Vector3 (1.45f, 1.45f, 1.41432f);
			GetComponent<SpriteRenderer> ().sprite = size4;
		}

		if (size == 5f) {
			transform.localScale = new Vector3 (1.65f, 1.65f, 1.41432f);
			GetComponent<SpriteRenderer> ().sprite = size5;
		}

		if (size == 6f) {
			transform.localScale = new Vector3 (1.80f, 1.80f, 1.41432f);
			GetComponent<SpriteRenderer> ().sprite = size6;
		}

		if (size == 6f && movementScript.playerStatus == true) {

			trail.GetComponent<TrailRenderer> ().time = 5f;
		}

		if (size != 6f) {
			trail.GetComponent<TrailRenderer> ().time = 0f;
		}

		if (size <= 0f) {
			size = 0f;
		}

		if (size >= 6f) {
			size = 6f;
		}

		if (movementScript.playerStatus == false) {

			trail.GetComponent<TrailRenderer> ().time = 0f;

		}

		movementScript.Speed (size);
	}



	public void Run(float increaseSize)
	{
		size += increaseSize;
		runCheck = true;
	}


	public void OnCollisionEnter2D (Collision2D other)
	{
		location = transform.position;

		if (other.gameObject.tag == "wall") {
			transform.position = location;
		}

	}
}
