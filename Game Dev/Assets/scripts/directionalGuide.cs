using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalGuide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		transform.position = actualMousePosition;

	}
}
