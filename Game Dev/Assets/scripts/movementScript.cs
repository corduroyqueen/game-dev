using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class movementScript : MonoBehaviour
{

	/// <summary>
	/// T//////////////////////////////////////////////////////////////	/// </summary>
	/// 
	/// 
	/// 
	/// 


	public GameObject sprite;

	public Sprite idleleft;
	public RuntimeAnimatorController idleleftcontrol;

	public Sprite walkingleft;
	public RuntimeAnimatorController walkingleftcontrol;

	public Sprite walkingup;
	public RuntimeAnimatorController walkingupcontrol;

	public Sprite walkingdown;
	public RuntimeAnimatorController walkingdowncontrol;

	public Sprite idleup;
	public Sprite idledown;



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
	public float scale;

	public GameObject endingScreen;
	public float alpha;

	public float separationx;
	public float separationy;

	public GameObject bagSize;
	private bagSizeScript bagSizeScript;
	public GameObject introController;
	private startingScript startingScript;

	public GameObject trail;

	public bool platformCheck;
	public bool dashCheck;
	public bool wallCheck;
	public bool windUpCheck;
	public bool hittingCheck;
	public static bool playerStatus;
	public bool dying;
	public bool arrowDying;
	public bool swinging;

	public bool winCondition;
	public bool ending;

	public bool botright = false;
	public bool topright = false;
	public bool topleft = false;
	public bool botleft = false;

	float mouseX;
	float mouseY;

	float directionX;
	float directionY;

	public float increment;
	public float swingTimer;

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
	public GameObject dashParts;
	public GameObject actualDashParts;


	Vector3 shaking;
	// Use this for initialization
	void Start ()
	{

		slow = 1f;

		playerrb = GetComponent<Rigidbody2D> ();

		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));

		startingScript = (startingScript)introController.GetComponent (typeof(startingScript));


		dashCheck = false;
		wallCheck = false;
		windUpCheck = false;
		hittingCheck = false;
		dying = false;

		numberOf1 = 0f;
		numberOf2 = 0f;
		numberOf3 = 0f;
		numberOf4 = 0f;
		numberOf5 = 0f;
		numberOf6 = 0f;

		scale = 0.8429087f;

		winCondition = false;

		endingScreen.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (startingScript.intro == true) {
			arrowDying = true;
		} else {
			arrowDying = false;
		}

		transform.localScale = new Vector3 (scale, scale, scale);

		if (playerStatus == false) {

			playerrb.velocity = new Vector3 (0f, 0f, 0f);
			scale = 0.8429087f;

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

			//dashRect.transform.localScale = new Vector3 (4.6f, dashRect.transform.localScale.y, dashRect.transform.localScale.z);

			var dir = actualMouse3 - dashRect.transform.position;
			var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			dashRect.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		}
		if (Input.GetMouseButtonUp (1)) {

			dashRect.transform.localScale = new Vector3 (0f, dashRect.transform.localScale.y, dashRect.transform.localScale.z);

		}
		if (Input.GetKey (KeyCode.A)) {
			//transform.position = new Vector3 (transform.position.x - (0.1f * slow), transform.position.y, 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (-7f * slow, playerrb.velocity.y);
				hittingCheck = false;
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = walkingleft;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingleftcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);
			sprite.GetComponent<SpriteRenderer> ().sprite = idleleft;
			sprite.GetComponent<Animator> ().runtimeAnimatorController = idleleftcontrol;
			sprite.GetComponent<SpriteRenderer> ().flipX = false;
		}
		if (Input.GetKey (KeyCode.A) && windUpCheck == true || dying == true || arrowDying == true) {

			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);

		}


		if (Input.GetKey (KeyCode.D)) {
			//transform.position = new Vector3 (transform.position.x + (0.1f * slow), transform.position.y, 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (7f * slow, playerrb.velocity.y);
				hittingCheck = false;
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = walkingleft;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingleftcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = true;
			}
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);
			sprite.GetComponent<SpriteRenderer> ().sprite = idleleft;
			sprite.GetComponent<Animator> ().runtimeAnimatorController = idleleftcontrol;
			sprite.GetComponent<SpriteRenderer> ().flipX = true;
		}
		if (Input.GetKey (KeyCode.D) && windUpCheck == true || dying == true || arrowDying == true) {

			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);

		}

			
		if (Input.GetKey (KeyCode.W)) {
			//transform.position = new Vector3 (transform.position.x, transform.position.y + (0.1f * slow), 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (playerrb.velocity.x, 7f * slow);
				hittingCheck = false;
				if (Input.GetKeyDown (KeyCode.A) == false || Input.GetKey (KeyCode.D) == false) {
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = walkingup;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingupcontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = true;
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
			sprite.GetComponent<SpriteRenderer> ().sprite = idleup;
			sprite.GetComponent<Animator> ().enabled = false;
		}
		if (Input.GetKey (KeyCode.W) && windUpCheck == true || dying == true || arrowDying == true) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
		}


		if (Input.GetKey (KeyCode.S)) {
			//transform.position = new Vector3 (transform.position.x, transform.position.y - (0.1f * slow), 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (playerrb.velocity.x, -7f * slow);
				hittingCheck = false;
				if (Input.GetKeyDown (KeyCode.A) == false || Input.GetKey (KeyCode.D) == false) {
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = walkingdown;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingdowncontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = true;
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
			sprite.GetComponent<SpriteRenderer> ().sprite = idledown;
			sprite.GetComponent<Animator> ().enabled = false;
		}
		if (Input.GetKey (KeyCode.W) && windUpCheck == true || dying == true || arrowDying == true) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
		}


		if (windUpCheck == false && Input.GetKey (KeyCode.None)) {

			playerrb.velocity = new Vector2 (0f, 0f);

		}

		directionX = (actualMousePosition.x - transform.position.x);
		directionY = (actualMousePosition.y - transform.position.y);


	

		if (Input.GetMouseButtonDown (0) && bagSizeScript.size == 6f) {
			windUpCheck = true;
		}

		if (Input.GetMouseButtonUp (0) && bagSizeScript.size == 6f && Camera.main.orthographicSize <= 4f) {
			windUpCheck = false;
			hittingCheck = true;

			swinging = true;


		}

		if (Input.GetMouseButtonUp (0) && bagSizeScript.size == 6f) {
			windUpCheck = false;
		}

		if (windUpCheck == true && Camera.main.orthographicSize >= 4f) {
			Camera.main.orthographicSize -= 0.1f;
		}

		if (windUpCheck == false && Camera.main.orthographicSize <= 6.911552f) {
			Camera.main.orthographicSize += 0.5f;
		}

		separationx = Math.Abs(bagSize.transform.position.x) - Math.Abs(transform.position.x);
		separationy = Math.Abs(bagSize.transform.position.y) - Math.Abs(transform.position.y);

		if(
			bagSize.transform.position.x >= transform.position.x
			&&
			bagSize.transform.position.y <= transform.position.y)
		{
			botright = true;
			topright = false;
			topleft = false;
			botleft = false;
		}
		if(
			bagSize.transform.position.x >= transform.position.x
			&&
			bagSize.transform.position.y >= transform.position.y)
		{
			botright = false;
			topright = true;
			topleft = false;
			botleft = false;
		}
		if(
			bagSize.transform.position.x <= transform.position.x
			&&
			bagSize.transform.position.y >= transform.position.y)
		{
			botright = false;
			topright = false;
			topleft = true;
			botleft = false;
		}
		if(
			bagSize.transform.position.x <= transform.position.x
			&&
			bagSize.transform.position.y <= transform.position.y)
		{
			botright = false;
			topright = false;
			topleft = false;
			botleft = true;
		}


	

		if (swinging == true) {
			arrowDying = true;

			swingTimer++;

			if (botright == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (600f, 500f, 0f));
			}
			if (topright == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (-500f, 600f, 0f));
			}
			if (topleft == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (-600f, -500f, 0f));
			}
			if (botleft == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (500f, -600f, 0f));
			}
		}

		if (swingTimer == 10f) {

			swinging = false;
			arrowDying = false;
			swingTimer = 0f;
		}
			

		if (playerStatus == false) {
			arrowDying = false;
			dying = false;
			checkpointHandler (checkpointNum);
		}

	}

	void FixedUpdate ()
	{

		Vector2 actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Input.GetMouseButtonDown (0) && bagSizeScript.size <= 2f && dashCheck == false && dying == false && arrowDying == false) {

			dashCheck = true;
			clickMousePosition = new Vector2 (actualMousePosition.x, actualMousePosition.y);
			finalTarget = clickMousePosition;
		}

		if (dashCheck == true) {

			Vector3 actualMouse3 = new Vector3 (actualMousePosition.x, actualMousePosition.y, dashRect.transform.position.z);

			dashParts.transform.localScale = new Vector3 (1f, 1f, 1f);

			var dir = actualMouse3 - dashParts.transform.position;
			var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			dashParts.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			//actualDashParts.transform.localScale = new Vector3 (1f, 1.186369f, 1f);

			trail.GetComponent<TrailRenderer> ().time = 0.3f;

			//dashParts.transform.rotation = new Quaternion (dashParts.transform.rotation.x, -90f, dashParts.transform.rotation.z, dashParts.transform.rotation.w);debug


			movePlayer (finalTarget);
		}
		if (dashCheck == false) {

			dashParts.transform.localScale = new Vector3 (0f, 0f, 0f);
			actualDashParts.transform.localScale = new Vector3 (0f, 0f, 0f);
			//dashParts.transform.rotation = Quaternion.AngleAxis (0f,0f);

			trail.GetComponent<TrailRenderer> ().time = 0.0f;
		}

		if (dying == true) {

			scale -= 0.04f;
			transform.localScale = new Vector3 (scale, scale, scale);

			if (scale <= 0) {
				scale = 0.8429087f;
				playerStatus = false;
			}

		}

		if (ending == true) {

			arrowDying = true;
			alpha += 0.005f;
			endingScreen.GetComponent<SpriteRenderer> ().color = new Color (0f,0f,0f, alpha);

		}

	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "movingPlatform" || other.gameObject.name == "bagSize") {
			platformCheck = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
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

		if (other.gameObject.name == "end" && winCondition == true) {

			End ();

		}
	}

	public void OnCollisionStay2D (Collision2D other)
	{




		if (other.gameObject.tag == "wall" && platformCheck == false || other.gameObject.tag == "treasure") {
			if (dashCheck == false) {
				playerrb.velocity = new Vector2 (0f, 0f);
			}
		}

		if (other.gameObject.name == "bagSize") {

			playerrb.velocity = new Vector2 (0f, 0f);
		}


	}

	public void OnCollisionExit2D (Collision2D other){

		if (other.gameObject.name == "bagSize") {

			playerrb.velocity = new Vector2 (0f, 0f);
		}

	}

	public void Speed (float size)
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

	void movePlayer (Vector2 actualMousePosition)
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
			transform.position = new Vector2 (1.96f, -6.94f);
			bagSize.transform.position = new Vector2 (2.16f, -7.34f);
		}
		if (num == 1) {
			transform.position = new Vector2 (9.28f, 11f);
			bagSize.transform.position = new Vector2 (9.08f, 11f);
		}
		if (num == 2) {
			transform.position = new Vector2 (37.3f, 10.75f);
			bagSize.transform.position = new Vector2 (37.5f, 10.75f);
		}
		if (num == 3) {
			transform.position = new Vector2 (-12.49f, 15.06f);
			bagSize.transform.position = new Vector2 (-12.49f, 14.86f);
		}
		if (num == 4) {
			transform.position = new Vector2 (-12.37f, 31.02f);
			bagSize.transform.position = new Vector2 (-12.37f, 31.22f);
		}
		if (num == 5) {
			transform.position = new Vector2 (19.89543f, 50.5047f);
			bagSize.transform.position = new Vector2 (20.09543f, 50.5047f);
		}
		if (num == 6) {
			transform.position = new Vector2 (43.09f, 48.33f);
			bagSize.transform.position = new Vector2 (43.29f, 48.33f);
		}
		if (num == 7) {
			transform.position = new Vector2 (47.35f, 61.01f);
			bagSize.transform.position = new Vector2 (47.35f, 61.21f);
		}
		if (num == 8) {
			transform.position = new Vector2 (65.01f, 45.92385f);
			bagSize.transform.position = new Vector2 (64.81f, 45.92385f);
		}

	
			
	}

	public void Value (float v)
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

	public void GetSmaller ()
	{
		dying = true;

	}

	public void ArrowHit ()
	{
		arrowDying = true;


	}

	public void End(){

		ending = true;

	}
}