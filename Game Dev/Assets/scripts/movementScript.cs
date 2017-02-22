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

	public float testSpeed;

	private float xVelocity;
	private float yVelocity;

	String checkpointText;

	public float slow;
	public Rigidbody2D playerrb;

	public GameObject bagSize;
	private bagSizeScript bagSizeScript;

	public bool platformCheck;
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

	public float numberOf1;
	public float numberOf2;
	public float numberOf3;
	public float numberOf4;
	public float numberOf5;
	public float numberOf6;

	public GameObject dashRect;

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

		numberOf1 = 0f;
		numberOf2 = 0f;
		numberOf3 = 0f;
		numberOf4 = 0f;
		numberOf5 = 0f;
		numberOf6 = 0f;
	}

	// Update is called once per frame
	void Update () {

		if (playerStatus == false) {

			playerrb.velocity = new Vector3 (0f, 0f, 0f);

		}

		Vector2 actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);


		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);

		playerDirection.Normalize ();

		xVelocity = playerrb.velocity.x;
		yVelocity = playerrb.velocity.y;

		Vector2 playerPos = new Vector2 (transform.position.x, transform.position.y);

		float distance = Vector2.Distance (playerPos, actualMousePosition);

		if (Input.GetMouseButton (1)) {



			Vector3 actualMouse3 = new Vector3 (actualMousePosition.x, actualMousePosition.y, dashRect.transform.position.z);

			dashRect.transform.localScale = new Vector3 (4.6f, dashRect.transform.localScale.y, dashRect.transform.localScale.z);

			var dir = actualMouse3 - dashRect.transform.position;
			var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			dashRect.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		}
		if (Input.GetMouseButtonUp (1)) {

			dashRect.transform.localScale = new Vector3 (0f, dashRect.transform.localScale.y, dashRect.transform.localScale.z);

		}

		if(Input.GetKey (KeyCode.A) && windUpCheck == false)
		{
			//transform.position = new Vector3 (transform.position.x - (0.1f * slow), transform.position.y, 0f);

			playerrb.velocity = new Vector2(-7f * slow,playerrb.velocity.y);

			hittingCheck = false;
		}
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);
		}


		if(Input.GetKey (KeyCode.D) && windUpCheck == false)
		{
			//transform.position = new Vector3 (transform.position.x + (0.1f * slow), transform.position.y, 0f);

			playerrb.velocity = new Vector2(7f * slow,playerrb.velocity.y);

			hittingCheck = false;
		}
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);
		}

			
		if(Input.GetKey (KeyCode.W) && windUpCheck == false)
		{
			//transform.position = new Vector3 (transform.position.x, transform.position.y + (0.1f * slow), 0f);

			playerrb.velocity = new Vector2(playerrb.velocity.x,7f * slow);

			hittingCheck = false;
		}
		if (Input.GetKeyUp (KeyCode.W)) 
		{
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
		}


		if(Input.GetKey (KeyCode.S) && windUpCheck == false)
		{
			//transform.position = new Vector3 (transform.position.x, transform.position.y - (0.1f * slow), 0f);

			playerrb.velocity = new Vector2(playerrb.velocity.x,-7f * slow);

			hittingCheck = false;
		}
		if (Input.GetKeyUp (KeyCode.S)) 
		{
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
		}




		directionX = (actualMousePosition.x - transform.position.x);
		directionY = (actualMousePosition.y - transform.position.y);


	

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

	void FixedUpdate(){

		Vector2 actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Input.GetMouseButtonDown (0) && bagSizeScript.size <= 2f && dashCheck == false) {

			dashCheck = true;
			clickMousePosition = new Vector2 (actualMousePosition.x, actualMousePosition.y);
			finalTarget = clickMousePosition;
		}

		if (dashCheck == true) {
			movePlayer (finalTarget);
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "movingPlatform" || other.gameObject.name == "bagSize") {
			platformCheck = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "movingPlatform" || other.gameObject.name == "bagSize") {
			platformCheck = false;
		}

	}

	public void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "wall" && increment >= 7f) {
			dashCheck = false;
			increment = 20f;
			playerrb.velocity = new Vector2 (0f, 0f);

		}
	}

	public void OnCollisionStay2D (Collision2D other)
	{




		if (other.gameObject.tag == "wall" && platformCheck == false) {
			if (dashCheck == false) {
				playerrb.velocity = new Vector2 (0f, 0f);
			}
		}

		if (other.gameObject.name == "bagSize") {

			playerrb.velocity = new Vector2 (0f, 0f);
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
		if (num == 5) {
			transform.position = new Vector2 (20.09543f,50.5047f);
		}
		if (num == 6) {
			transform.position = new Vector2 (43.29f, 48.33f);
		}
		if (num == 7) {
			transform.position = new Vector2 (47.35f, 61.21f);
		}
		if (num == 8) {
			transform.position = new Vector2 (64.81f, 45.92385f);
		}

	
			
	}

	public void Value(float v)
	{
		if (v == 1f) {
			numberOf1 += 1f;
		}

		if (v == 2f) {
			numberOf2 += 1f;
		}

		if (v == 3f) {
			numberOf3 += 1f;
		}

		if (v == 4f) {
			numberOf4 += 1f;
		}

		if (v == 5f) {
			numberOf5 += 1f;
		}

		if (v == 6f) {
			numberOf6 += 1f;
		}


	}
}