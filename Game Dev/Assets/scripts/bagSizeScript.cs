 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bagSizeScript : MonoBehaviour {

	public GameObject player;
	private movementScript movementScript;

	private bool runCheck = false;
	public float size = 0f;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));


	}
	
	// Update is called once per frame
	void Update () {

		if (runCheck == true) {
			runCheck = false;
		}

		if (size == 0f) {
			transform.localScale = new Vector3 (0.85f, 0.85f, 1.41432f);
		}

		if (size == 1f) {
			transform.localScale = new Vector3 (1f, 1f, 1.41432f);
		}

		if (size == 2f) {
			transform.localScale = new Vector3 (1.15f, 1.15f, 1.41432f);
		}

		if (size == 3f) {
			transform.localScale = new Vector3 (1.30f, 1.30f, 1.41432f);
		}

		if (size == 4f) {
			transform.localScale = new Vector3 (1.45f, 1.45f, 1.41432f);
		}

		if (size == 5f) {
			transform.localScale = new Vector3 (1.65f, 1.65f, 1.41432f);
		}

		if (size == 6f) {
			transform.localScale = new Vector3 (1.80f, 1.80f, 1.41432f);
		}

		if (size <= 0f) {
			size = 0f;
		}

		if (size >= 6f) {
			size = 6f;
		}

		movementScript.Speed (size);
	
	}



	public void Run(float increaseSize)
	{
		size += increaseSize;
		runCheck = true;
	}


}
