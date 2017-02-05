using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movementScript : MonoBehaviour {


	public float slow;

	// Use this for initialization
	void Start () {

		slow = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey (KeyCode.A))
		{
			transform.position = new Vector3 (transform.position.x - (0.1f * slow), transform.position.y, 0f);
		}

		if(Input.GetKey (KeyCode.D))
		{
			transform.position = new Vector3 (transform.position.x + (0.1f * slow), transform.position.y, 0f);
		}
			
		if(Input.GetKey (KeyCode.W))
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + (0.1f * slow), 0f);
		}

		if(Input.GetKey (KeyCode.S))
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - (0.1f * slow), 0f);
		}
			
	}

	public void Speed(float size)
	{
		if (size == 0f) {
			slow = 1f;
		}

		if (size == 1f) {
			slow = .95f;
		}

		if (size == 2f) {
			slow = .9f;
		}

		if (size == 3f) {
			slow = .85f;
		}

		if (size == 4f) {
			slow = .8f;
		}

		if (size == 5f) {
			slow = .75f;
		}

		if (size == 6f) {
			slow = .7f;
		}
	}
}