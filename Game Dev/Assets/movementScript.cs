using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey (KeyCode.A))
		{
			transform.position = new Vector3 (transform.position.x - 0.1f, transform.position.y, 0f);
		}

		if(Input.GetKey (KeyCode.D))
		{
			transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y, 0f);
		}
			
		if(Input.GetKey (KeyCode.W))
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.1f, 0f);
		}

		if(Input.GetKey (KeyCode.S))
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, 0f);
		}
	}
}
