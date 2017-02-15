using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class movementScript : MonoBehaviour {

	/// <summary>
	/// T//////////////////////////////////////////////////////////////	/// </summary>
	/// 
	public Camera testCamera;

	private Vector3 testMousePosition;
	private Vector3 testDirection;
	private float testDistanceFromObject;








	String checkpointText;

	public float slow;
	public Rigidbody2D playerrb;

	public GameObject bagSize;
	private bagSizeScript bagSizeScript;


	public bool dashCheck;
	public bool wallCheck;
	public bool windUpCheck;
	public bool hittingCheck;
	public static bool playerStatus;

	float mouseX;
	float mouseY;

	float directionX;
	float directionY;

	public float increment;

	public float checkpointNum;


	public Vector2 clickMousePosition;
	public Vector2 finalTarget;

	Vector2 playerLocation;
	Vector2 playerDirection;

	// Use this for initialization
	void Start () {

		slow = 1f;

		playerrb = GetComponent<Rigidbody2D> ();

		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));


		dashCheck = false;
		wallCheck = false;
		windUpCheck = false;
		hittingCheck = false;


	}

	// Update is called once per frame
	void Update () {
	
		Vector2 actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);

		playerDirection.Normalize ();


		if(Input.GetKey (KeyCode.A) && windUpCheck == false)
		{
			transform.position = new Vector3 (transform.position.x - (0.1f * slow), transform.position.y, 0f);
			hittingCheck = false;
		}

		if(Input.GetKey (KeyCode.D) && windUpCheck == false)
		{
			transform.position = new Vector3 (transform.position.x + (0.1f * slow), transform.position.y, 0f);
			hittingCheck = false;
		}
			
		if(Input.GetKey (KeyCode.W) && windUpCheck == false)
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + (0.1f * slow), 0f);
			hittingCheck = false;
		}

		if(Input.GetKey (KeyCode.S) && windUpCheck == false)
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - (0.1f * slow), 0f);
			hittingCheck = false;
		}








		directionX = (actualMousePosition.x - transform.position.x);
		directionY = (actualMousePosition.y - transform.position.y);


		if(Input.GetMouseButtonDown(0) && bagSizeScript.size <= 2f && dashCheck == false){

			dashCheck = true;
			clickMousePosition = new Vector2 (directionX,directionY);
			finalTarget = clickMousePosition * 10f;



			//playerrb.transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 ((clickMousePosition.y - transform.position.y), (clickMousePosition.x - -transform.position.x)) * Mathf.Rad2Deg - 90);
			//testDistanceFromObject = (Input.mousePosition - transform.position).magnitude;
		}

		if (dashCheck == true && wallCheck == false) {
			movePlayer(finalTarget);
		}

		if(Input.GetKeyDown(KeyCode.Space) && bagSizeScript.size == 6f) {
			windUpCheck = true;
		}

		if(Input.GetKeyUp(KeyCode.Space) && bagSizeScript.size == 6f) {
			windUpCheck = false;
			hittingCheck = true;
		}




		if (playerStatus == false) {
			checkpointHandler (checkpointNum);
		}

	}

	public void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "wall") {
			dashCheck = false;
			increment = 0f;
			increment = 20f;

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

	void movePlayer(Vector2 actualMousePosition)
	{

		Debug.Log (transform.position);
		Debug.Log (actualMousePosition);
		transform.position = Vector3.MoveTowards (transform.position, actualMousePosition, 20f * Time.deltaTime);

			//playerrb.AddForce(testDirection * 10 * testDistanceFromObject * Time.deltaTime);

		increment++;

		if (increment >= 11) {
			playerrb.velocity = Vector2.zero;
			increment = 0f;
			dashCheck = false;
		}
	}


	void checkpointHandler (float num)
	{
		playerStatus = true;
		if (num == 0) {
			transform.position = new Vector2 (1.376f, -1.71f);
		}
		if (num == 1) {
			transform.position = new Vector2 (9.28f, 11f);
		}
		if (num == 2) {
			transform.position = new Vector2 (37.3f, 10.75f);
		}
		if (num == 3) {
			transform.position = new Vector2 (-12.49f, 15.06f);
		}
		if (num == 4) {
			transform.position = new Vector2 (-12.37f,31.02f);
		}

	}
}