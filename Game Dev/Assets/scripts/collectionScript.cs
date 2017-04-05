using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collectionScript : MonoBehaviour {

	public GameObject bagSize;
	private bagSizeScript bagSizeOtherScript; 
	private static float theSize;

	public GameObject player;
	private movementScript movementScript; 

	public float value;

	private bool collect;

	public bool finaltreasure;

	// Use this for initialization
	void Start () {

		//GameObject theBagSize = GameObject.Find ("bagSize");

		//bagSizeScript bagSizeScript = theBagSize.GetComponent<bagSizeScript>();

		collect = false;
		bagSizeOtherScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));
		bagSizeOtherScript = bagSize.GetComponent<bagSizeScript> ();

		player = GameObject.Find ("player");
		movementScript = (movementScript)player.GetComponent (typeof(movementScript));
		movementScript = player.GetComponent<movementScript> ();


		theSize = bagSizeOtherScript.size;


	}
	
	// Update is called once per frame
	void Update () {

		theSize = bagSizeOtherScript.size;

		if (theSize <= 5f && collect == true && Input.GetKey(KeyCode.E)) {
			bagSizeOtherScript.Run (value);
			movementScript.Value (value);

			if (finaltreasure == true) {

				movementScript.winCondition = true;

			}
			GameObject.Find ("pickup").GetComponent<AudioSource> ().Play ();
			Destroy (this.gameObject);
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
