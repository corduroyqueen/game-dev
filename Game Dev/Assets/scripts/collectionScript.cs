using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collectionScript : MonoBehaviour {

	public GameObject bagSize;
	private bagSizeScript bagSizeOtherScript; 
	private static float theSize;



	private bool collect;



	// Use this for initialization
	void Start () {

		//GameObject theBagSize = GameObject.Find ("bagSize");

		//bagSizeScript bagSizeScript = theBagSize.GetComponent<bagSizeScript>();

		collect = false;
		bagSizeOtherScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));
		bagSizeOtherScript = bagSize.GetComponent<bagSizeScript> ();

		theSize = bagSizeOtherScript.size;


	}
	
	// Update is called once per frame
	void Update () {

		theSize = bagSizeOtherScript.size;

		if (theSize <= 5f && collect == true && Input.GetKey(KeyCode.E)) {
			bagSizeOtherScript.Run ();
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
