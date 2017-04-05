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
	/// whats up
	/// im trying to comment this as fast as i can 
	/// if u have any questions text me 
	/// 310 248 0409
	/// 
	/// 

	//these are all basically my public variables for changing the sprite of the sprite gameobject since i didnt really learn how to use the animator

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

	public Sprite prepleft;
	public RuntimeAnimatorController prepleftcontrol;

	public Sprite prepright;
	public RuntimeAnimatorController preprightcontrol;

	public Sprite hitright;
	public RuntimeAnimatorController hitrightcontrol;

	public Sprite hitleft;
	public RuntimeAnimatorController hitleftcontrol;

	public Sprite dashdown;
	public RuntimeAnimatorController dashdowncontrol;

	public Sprite dashup;
	public RuntimeAnimatorController dashupcontrol;


	//these are for checking animation stuff and animation states, probably dont mess with these
	public bool walkingupcheck;
	public bool walkingdowncheck;
	public bool runanimation;
	public bool dashanimation;
	public bool enddashcheck;

	//this is a test stuff cant remember what i was testing
	public Camera testCamera;
	private Vector3 testMousePosition;
	private Vector3 testDirection;
	private float testDistanceFromObject;
	public float testSpeed;

	//these were variables that i was using to measure the players velocity that i didnt end up using
	private float xVelocity;
	private float yVelocity;

	//??
	String checkpointText;

	//these are important. slow is the degree by which the player is slowed when the bag gets bigger
	public float slow;
	//playerrb is the player rigidbody
	public Rigidbody2D playerrb;
	//this is the scale of the bag
	public float scale;

	//this is ending screen and the transparency variable i use for it
	public GameObject endingScreen;
	public float alpha;

	//this is the separation between the player and the bag, cant remember what i used this for though
	public float separationx;
	public float separationy;


	//this is accessing the bagsize stuff and the starting screen stuff
	public GameObject bagSize;
	private bagSizeScript bagSizeScript;
	public GameObject introController;
	private startingScript startingScript;

	//thetrail
	public GameObject trail;

	//all variables checking the state of the player, these are used all over
	public bool platformCheck;
	public bool dashCheck;
	public bool wallCheck;
	public bool windUpCheck;
	public bool hittingCheck;
	public static bool playerStatus;
	public bool dying;
	public bool arrowDying;
	public bool swinging;

	//self explanatory i think
	public bool winCondition;
	public bool ending;

	//where the bag is in relation to the player, used to determine how to propel the bag when you hit
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
	//the checkpoint the player is at
	public float checkpointNum;

	//variables used to determine where to dash to
	public Vector2 clickMousePosition;
	public Vector2 finalTarget;

	Vector2 playerLocation;
	Vector2 playerDirection;
	//unused system, but number of different treasure sizes the player has
	public float numberOf1;
	public float numberOf2;
	public float numberOf3;
	public float numberOf4;
	public float numberOf5;
	public float numberOf6;
	//might still use these, for particles during the dash
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

		dashanimation = false;
		enddashcheck = false;
	}

	// Update is called once per frame
	void Update ()
	{
		//for setting the sprite at the end of a dash
		if (enddashcheck == true) {
			enddashcheck = false;
		}

		//arrowDying is actually just making the player still
		if (startingScript.intro == true) {
			arrowDying = true;
		} else {
			arrowDying = false;
		}
		transform.localScale = new Vector3 (scale, scale, scale);

		//playerStatus is whether the player is alive or not
		if (playerStatus == false) {

			playerrb.velocity = new Vector3 (0f, 0f, 0f);
			scale = 0.8429087f;

		}
		//used for the dash
		Vector2 actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);


		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);

		playerDirection.Normalize ();

		xVelocity = playerrb.velocity.x;
		yVelocity = playerrb.velocity.y;
		//used for the dash
		Vector2 playerPos = new Vector2 (transform.position.x, transform.position.y);
		//not being used any more, originally the dash worked on the distance between the player and the mouse
		float distance = Vector2.Distance (playerPos, actualMousePosition);
		//this is used for the dash guide thing but im not used it any more, kept it here just in case
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

		//all the next stuff is just walking and the animations
		if (Input.GetKey (KeyCode.W)) {
			//transform.position = new Vector3 (transform.position.x, transform.position.y + (0.1f * slow), 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (playerrb.velocity.x, 7f * slow);
				hittingCheck = false;
				walkingupcheck = true;
				if(walkingupcheck == true && dashCheck == false){
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = walkingup;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingupcontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = true;
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
			walkingupcheck = false;
			if (dashCheck == false) {
				sprite.GetComponent<SpriteRenderer> ().sprite = idleup;
				sprite.GetComponent<Animator> ().enabled = false;
			}


		}
		if (Input.GetKey (KeyCode.W) && windUpCheck == true || dying == true || arrowDying == true) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
		}


		if (Input.GetKey (KeyCode.S)) {
			//transform.position = new Vector3 (transform.position.x, transform.position.y - (0.1f * slow), 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (playerrb.velocity.x, -7f * slow);
				hittingCheck = false;
				walkingdowncheck = true;

				if (walkingdowncheck == true && dashCheck == false){
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = walkingdown;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingdowncontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = true;
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
			walkingdowncheck = false;
			if (dashCheck == false) {
				sprite.GetComponent<SpriteRenderer> ().sprite = idledown;
				sprite.GetComponent<Animator> ().enabled = false;
			}

		}
		if (Input.GetKey (KeyCode.W) && windUpCheck == true || dying == true || arrowDying == true) {
			playerrb.velocity = new Vector2 (playerrb.velocity.x, 0f);
		}


		if (Input.GetKey (KeyCode.A)) {
			//transform.position = new Vector3 (transform.position.x - (0.1f * slow), transform.position.y, 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (-7f * slow, playerrb.velocity.y);
				hittingCheck = false;
				if (walkingupcheck == false && walkingdowncheck == false && walkingupcheck == false && dashanimation == false && dashCheck == false) {
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = walkingleft;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingleftcontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = false;
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);
			if (walkingupcheck == false && walkingdowncheck == false && walkingupcheck == false && dashanimation == false && dashCheck == false) {
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = idleleft;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = idleleftcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}
		}
		if (Input.GetKey (KeyCode.A) && windUpCheck == true || dying == true || arrowDying == true) {

			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);

		}


		if (Input.GetKey (KeyCode.D)) {
			//transform.position = new Vector3 (transform.position.x + (0.1f * slow), transform.position.y, 0f);
			if (windUpCheck == false && dying == false) {
				playerrb.velocity = new Vector2 (7f * slow, playerrb.velocity.y);
				hittingCheck = false;
				if (walkingupcheck == false && walkingdowncheck == false && walkingupcheck == false && dashanimation == false && dashCheck == false) {
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = walkingleft;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = walkingleftcontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = true;
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);
			if (walkingupcheck == false && walkingdowncheck == false && walkingupcheck == false && dashanimation == false && dashCheck == false) {
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = idleleft;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = idleleftcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = true;
			}
		}
		if (Input.GetKey (KeyCode.D) && windUpCheck == true || dying == true || arrowDying == true) {

			playerrb.velocity = new Vector2 (0f, playerrb.velocity.y);

		}

			


		if (windUpCheck == false && Input.GetKey (KeyCode.None)) {

			playerrb.velocity = new Vector2 (0f, 0f);

		}

		directionX = (actualMousePosition.x - transform.position.x);
		directionY = (actualMousePosition.y - transform.position.y);


	
		//preparing for the max bag size hit
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
		//this is setting how the camera behaves when you prepare to hit for the bag
		if (windUpCheck == true && Camera.main.orthographicSize >= 4f) {
			GameObject.Find ("charging").GetComponent<AudioSource> ().Play ();
			Camera.main.orthographicSize -= 0.1f;
		}

		if (windUpCheck == false && Camera.main.orthographicSize <= 6.911552f) {
			GameObject.Find ("charging").GetComponent<AudioSource> ().Stop ();
			Camera.main.orthographicSize += 0.5f;
		}

		if (Camera.main.orthographicSize >= 6.91f) {
			GameObject.Find ("charging").GetComponent<AudioSource> ().Stop ();
		}

		separationx = Math.Abs(bagSize.transform.position.x) - Math.Abs(transform.position.x);
		separationy = Math.Abs(bagSize.transform.position.y) - Math.Abs(transform.position.y);

		//figuring out the bag position
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

		if (windUpCheck == true) {



			if (botright == true) {
				

			}
			if (topright == true) {
				
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = prepleft;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = prepleftcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}
			if (topleft == true) {
				
			}
			if (botleft == true) {
				
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = prepright;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = preprightcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}

		}
	
		//setting how the bag behaves when you swing depending on its position
		if (swinging == true) {
			GameObject.Find ("swing").GetComponent<AudioSource> ().Play ();
			arrowDying = true;

			swingTimer++;
				
			if (botright == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (600f, 500f, 0f));

			}
			if (topright == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (-500f, 600f, 0f));
				if (swingTimer <= 9f && swingTimer >= 1f) {
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = hitleft;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = hitleftcontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = false;
				}
			}
			if (topleft == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (-600f, -500f, 0f));
			}
			if (botleft == true) {
				bagSize.GetComponent<Rigidbody2D> ().AddForce(new Vector3 (500f, -600f, 0f));
				if (swingTimer <= 9f && swingTimer >= 1f) {
					sprite.GetComponent<Animator> ().enabled = true;
					sprite.GetComponent<SpriteRenderer> ().sprite = hitright;
					sprite.GetComponent<Animator> ().runtimeAnimatorController = hitrightcontrol;
					sprite.GetComponent<SpriteRenderer> ().flipX = false;
				}
			}
		}
		//stopping the bag after a certain amount of time
		if (swingTimer >= 8f) {



			if (botright == true) {

			}
			if (topright == true) {
				runanimation = false;
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = idleleft;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = idleleftcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = false;

			}
			if (topleft == true) {

			}
			if (botleft == true) {
				runanimation = false;
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = idleleft;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = idleleftcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = true;

			}


		}

		if (swingTimer == 10f) {

			swinging = false;
			arrowDying = false;
			swingTimer = 0f;

		}

		if (playerStatus == false) {
			GameObject.Find ("death").GetComponent<AudioSource> ().Play ();
			arrowDying = false;
			dying = false;
			checkpointHandler (checkpointNum);
		}
	}

	void FixedUpdate ()
	{
		//how the player dashes
		Vector2 actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Input.GetMouseButtonDown (0) && bagSizeScript.size <= 2f && dashCheck == false && dying == false && arrowDying == false) {

			dashCheck = true;
			clickMousePosition = new Vector2 (actualMousePosition.x, actualMousePosition.y);
			finalTarget = clickMousePosition;

			if (clickMousePosition.x >= transform.position.x && clickMousePosition.y >= transform.position.y) {
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = dashup;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = dashupcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}
			if (clickMousePosition.x >= transform.position.x && clickMousePosition.y <= transform.position.y) {
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = dashdown;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = dashdowncontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}
			if (clickMousePosition.x <= transform.position.x && clickMousePosition.y >= transform.position.y) {
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = dashup;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = dashupcontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = true;
			}
			if (clickMousePosition.x <= transform.position.x && clickMousePosition.y <= transform.position.y) {
				sprite.GetComponent<Animator> ().enabled = true;
				sprite.GetComponent<SpriteRenderer> ().sprite = dashdown;
				sprite.GetComponent<Animator> ().runtimeAnimatorController = dashdowncontrol;
				sprite.GetComponent<SpriteRenderer> ().flipX = true;
			}
		}
		//the actual movement of a dash
		if (dashCheck == true) {

			Vector3 actualMouse3 = new Vector3 (actualMousePosition.x, actualMousePosition.y, dashRect.transform.position.z);

			dashParts.transform.localScale = new Vector3 (1f, 1f, 1f);

			var dir = actualMouse3 - dashParts.transform.position;
			var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			dashParts.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			//actualDashParts.transform.localScale = new Vector3 (1f, 1.186369f, 1f);

			trail.GetComponent<TrailRenderer> ().time = 0.3f;

			//dashanimation = true;






			//dashParts.transform.rotation = new Quaternion (dashParts.transform.rotation.x, -90f, dashParts.transform.rotation.z, dashParts.transform.rotation.w);debug


			movePlayer (finalTarget);
		}
		//animation after a dash
		if (dashCheck == false) {
			//dashanimation = false;

			dashParts.transform.localScale = new Vector3 (0f, 0f, 0f);
			actualDashParts.transform.localScale = new Vector3 (0f, 0f, 0f);
			//dashParts.transform.rotation = Quaternion.AngleAxis (0f,0f);

			if (enddashcheck == true) {
				if (clickMousePosition.y >= transform.position.y) {
					sprite.GetComponent<Animator> ().enabled = false;
					sprite.GetComponent<SpriteRenderer> ().sprite = idleup;
					sprite.GetComponent<SpriteRenderer> ().flipX = false;
				}
				if (clickMousePosition.y <= transform.position.y) {
					sprite.GetComponent<Animator> ().enabled = false;
					sprite.GetComponent<SpriteRenderer> ().sprite = idledown;
					sprite.GetComponent<SpriteRenderer> ().flipX = false;
				}
			}

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
		//making sure the player moves when theyre on a platform
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
		//making sure the player doesnt go in random directions when they touch a wall
		if (other.gameObject.tag == "wall" && increment >= 7f) {
			dashCheck = false;
			increment = 20f;
			playerrb.velocity = new Vector3 (0f, 0f, 0f);
			enddashcheck = true;

		}

		if (other.gameObject.name == "end" && winCondition == true) {

			End ();

		}
	}

	public void OnCollisionStay2D (Collision2D other)
	{




		if (other.gameObject.tag == "wall" && platformCheck == false || other.gameObject.tag == "treasure") {
			if (dashCheck == false) {
				playerrb.velocity = new Vector3 (0f, 0f, 0f);
				enddashcheck = true;
			}
		}

		if (other.gameObject.name == "bagSize" || other.gameObject.name == "dropoff") {

			playerrb.velocity = new Vector3 (0f, 0f, 0f);
		}


	}

	public void OnCollisionExit2D (Collision2D other){

		if (other.gameObject.name == "bagSize" || other.gameObject.name == "dropoff") {

			playerrb.velocity = new Vector3 (0f, 0f, 0f);
		}

	}

	public void Speed (float size)
	{
		//setting the actual speed of the player
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
		//moving the player for the dash
		transform.position = Vector3.MoveTowards (transform.position, actualMousePosition, 20f * Time.deltaTime);
		GameObject.Find ("dash").GetComponent<AudioSource> ().Play ();
		//playerrb.AddForce(testDirection * 10 * testDistanceFromObject * Time.deltaTime);

		increment++;



		if (increment >= 11) {
			playerrb.velocity = Vector2.zero;
			increment = 0f;
			dashCheck = false;
			enddashcheck = true;
		}
	}


	void checkpointHandler (float num)
	{
		//setting the checkpoints of the player
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
		//how many of each treasure the player has
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