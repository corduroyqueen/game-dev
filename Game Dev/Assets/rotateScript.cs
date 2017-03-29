using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour {

	public float increment;

	// Use this for initialization
	void Start () {

		increment = 0f;

	}
	
	// Update is called once per frame
	void Update () {

		increment--;

		if (increment <= -359f) {

			increment = 0f;

		}

		transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,increment,transform.rotation.w);

	}
}
