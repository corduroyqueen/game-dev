using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedArrowScript : MonoBehaviour {
	
	public GameObject arrowPrefab;
	public float xDistanceFromParent;
	public float yDistanceFromParent;
	public float rotation;

	float increment;
	float increment2;
	bool readyFire;


	public float timer;

	// Use this for initialization
	void Start ()
	{
		readyFire = true;
	}

	// Update is called once per frame
	void Update ()
	{

		if (readyFire == false) {
			increment++;
		}
		if (increment >= 100) {
			readyFire = true;
			increment = 0f;
		}


		increment2++;

		if (increment2 >= timer) {

			(Instantiate (arrowPrefab, new Vector2 (transform.position.x + xDistanceFromParent, transform.position.y + yDistanceFromParent), new Quaternion (0f, 0f, 0f, 0f)) as GameObject).transform.parent = this.transform;
			increment2 = 0f;

		}
	}
}
