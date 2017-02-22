using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpingCamera : MonoBehaviour {

	public GameObject player;
	public float z;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		z = -11.86368f;

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.Lerp (transform.position, player.transform.position, 0.9f);

		transform.position = new Vector3 (transform.position.x, transform.position.y, z);
	}
}
