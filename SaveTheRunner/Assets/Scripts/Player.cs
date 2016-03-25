using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private bool isJumping;
	private bool isMovingLeft;
	private bool isMovingRight;
	private int i, j;

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
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ground") {
			Debug.Log ("Collides with Ground");
			isJumping = false;
		}
	}
}
