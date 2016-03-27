﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private bool isJumping;
	private bool isMovingLeft;
	private bool isMovingRight;
	private int i, j;
	private RaycastHit objectHit;


	// Use this for initialization
	void Start () {
		isJumping = false;
		isMovingLeft = false;
		isMovingRight = false;
		i = 0;
		j = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && transform.position.x >= -0.5f) {
			isMovingLeft = true;
			//transform.Translate(new Vector3 (-1.0f, 0.0f, 0.0f));
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && transform.position.x <= 0.5f) {
			isMovingRight = true;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && !isJumping) {
			GetComponent<Rigidbody> ().AddForce (new Vector3(0.0f, 1.0f, 0.0f) * 200.0f);
			isJumping = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && !GameOptions.options.getGameStarted()) {
			GameOptions.options.setGameStarted (true);
		}

		if (isMovingLeft) {
			transform.Translate (new Vector3 (-0.05f, 0.0f, 0.0f));
			if (i++ >= 19) {
				isMovingLeft = false;
				i = 0;
			}
		}

		if (isMovingRight) {
			transform.Translate (new Vector3 (0.05f, 0.0f, 0.0f));
			if (j++ >= 19) {
				isMovingRight = false;
				j = 0;
			}
		}

		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 50f, Color.green);
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out objectHit, 50.0f)) {
			GameObject target = objectHit.collider.gameObject;
			if (target.tag.StartsWith ("Obstacle")) {
				Debug.Log ("About to Collide with " + target.name + " Distance = " + Vector3.Distance (transform.position, target.transform.position) + " Speed = " + GameOptions.options.getGameSpeed());
				if (Vector3.Distance (transform.position, target.transform.position) <= GameOptions.options.getGameSpeed () + 0.5f) {
					Debug.Log ("Collided with " + target.name);
					this.gameObject.SetActive (false);
					Destroy (this.gameObject);

				}
			}
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ground") {
			//Debug.Log ("Collides with Ground");
			isJumping = false;
		}
		if (other.gameObject.tag == "Obstacle1") {
			//Debug.Log ("Collides with Obstacle1");
		}
	}
}
