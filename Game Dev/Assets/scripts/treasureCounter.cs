using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class treasureCounter : MonoBehaviour {

	Text text;
	public GameObject bagSize;
	private bagSizeScript bagSizeScript;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));
		text.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		text.text = bagSizeScript.size.ToString();
	}
}
