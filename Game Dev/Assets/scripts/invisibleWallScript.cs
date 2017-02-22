using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleWallScript : MonoBehaviour {

	public bool active;
	public float valueToStartBlocking;

	public GameObject bagSize;
	private bagSizeScript bagSizeScript;

	// Use this for initialization
	void Start () {

		active = false;
		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));

	}
	
	// Update is called once per frame
	void Update () {


		if (bagSizeScript.size >= valueToStartBlocking) {

			this.GetComponent<BoxCollider2D> ().isTrigger = false;
			active = true;

		} else {
			this.GetComponent<BoxCollider2D> ().isTrigger = true;
			active = false;
		}
		
	}
}
