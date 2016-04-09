using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private bool isJumping;
	private bool isMovingLeft;
	private bool isMovingRight;
	private int jumpWait;
	private float origY, prevPosY, prevPosXLeft, prevPosXRight, startTime, moveLength, speed;
	private Vector3 startPosition;
	private RaycastHit objectHit;


	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		//startTime = Time.time;
		isJumping = false;
		isMovingLeft = false;
		isMovingRight = false;
		moveLength = 1.0f;
		origY = transform.position.y;
		jumpWait = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMovingLeft && !isJumping) {
			//transform.Translate (new Vector3 (-0.05f, 0.0f, 0.0f));
			//if (i++ >= 19) {
			//	isMovingLeft = false;
			//	i = 0;
			//}
//			GetComponent<Rigidbody> ().velocity = new Vector3(-1.0f, 0.0f, 0.0f) * 5.0f * GameOptions.options.getGameSpeed();
			float distCovered = (Time.time - startTime) * 2.0f * speed;
			float fracJourney = distCovered / moveLength;
			transform.position = Vector3.Lerp(transform.position, startPosition + Vector3.left, fracJourney);
			//Debug.Log ("MovesLeft");
			//if (transform.position.x < -1.0f) {
			if (Mathf.Abs(transform.position.x - (startPosition + Vector3.left).x) == 0.0f) {
//				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				transform.position = new Vector3 (prevPosXLeft -1.0f, transform.position.y, transform.position.z);
				isMovingLeft = false;
			}
		}

		if (isMovingLeft && isJumping) {
			GetComponent<Rigidbody> ().isKinematic = true;
			//transform.Translate (new Vector3 (-0.05f, 0.0f, 0.0f));
			//if (i++ >= 19) {
			//	isMovingLeft = false;
			//	i = 0;
			//}
			//			GetComponent<Rigidbody> ().velocity = new Vector3(-1.0f, 0.0f, 0.0f) * 5.0f * GameOptions.options.getGameSpeed();
			float distCovered = (Time.time - startTime) * 5.0f * speed;
			float fracJourney = distCovered / moveLength;
			transform.position = Vector3.Lerp(transform.position, new Vector3(startPosition.x - 1.0f, origY, transform.position.z), fracJourney);
			//Debug.Log ("MovesLeft");
			//if (transform.position.x < -1.0f) {
			if (Mathf.Abs(transform.position.x - (startPosition + Vector3.left).x) < 0.05f) {
				//				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				transform.position = new Vector3 (prevPosXLeft -1.0f, transform.position.y, transform.position.z);
				isMovingLeft = false;
				GetComponent<Rigidbody> ().isKinematic = false;
			}
		}

		if (isMovingRight && !isJumping) {
			//transform.Translate (new Vector3 (0.05f, 0.0f, 0.0f));
			//if (j++ >= 19) {
			//	isMovingRight = false;
			//	j = 0;
			//}
//			GetComponent<Rigidbody> ().velocity = new Vector3(1.0f, 0.0f, 0.0f) * 5.0f * GameOptions.options.getGameSpeed();
			float distCovered = (Time.time - startTime) * 2.0f * speed;
			float fracJourney = distCovered / moveLength;
			Debug.Log ("MovesRight");
			//Debug.Log ("MOVES " + distCovered + "    " + fracJourney + " --- " + Mathf.Abs(transform.position.x - (startPosition + Vector3.right).x));
			transform.position = Vector3.Lerp(transform.position, startPosition + Vector3.right, fracJourney);
			//if (transform.position.x - prevPosXRight > 1.0f) {
			if (Mathf.Abs(transform.position.x - (startPosition + Vector3.right).x) == 0.0f) {
//				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				transform.position = new Vector3 (prevPosXRight + 1.0f, transform.position.y, transform.position.z);
				isMovingRight = false;
			}
		}

		if (isMovingRight && isJumping) {
			GetComponent<Rigidbody> ().isKinematic = true;
			//transform.Translate (new Vector3 (0.05f, 0.0f, 0.0f));
			//if (j++ >= 19) {
			//	isMovingRight = false;
			//	j = 0;
			//}
			//			GetComponent<Rigidbody> ().velocity = new Vector3(1.0f, 0.0f, 0.0f) * 5.0f * GameOptions.options.getGameSpeed();
			float distCovered = (Time.time - startTime) * 5.0f * speed;
			float fracJourney = distCovered / moveLength;
			Debug.Log ("MovesRight");
			//Debug.Log ("MOVES " + distCovered + "    " + fracJourney + " --- " + Mathf.Abs(transform.position.x - (startPosition + Vector3.right).x));
			transform.position = Vector3.Lerp(transform.position, new Vector3(startPosition.x + 1.0f, origY, transform.position.z), fracJourney);
			//if (transform.position.x - prevPosXRight > 1.0f) {
			if (Mathf.Abs(transform.position.x - (startPosition + Vector3.right).x) < 0.05f) {
				//				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				transform.position = new Vector3 (prevPosXRight + 1.0f, transform.position.y, transform.position.z);
				isMovingRight = false;
				GetComponent<Rigidbody> ().isKinematic = false;
			}
		}

		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 50f, Color.green);
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out objectHit, 50.0f)) {
			GameObject target = objectHit.collider.gameObject;
			if (target.tag.StartsWith ("Obstacle")) {
				//Debug.Log ("About to Collide with " + target.name + " Distance = " + Vector3.Distance (transform.position, target.transform.position) + " Speed = " + GameOptions.options.getGameSpeed());
				if (Vector3.Distance (transform.position, target.transform.position) <= GameOptions.options.getGameSpeed () + 0.5f) {
					//Debug.Log ("Collided with " + target.name);
					//this.gameObject.SetActive (false);
					//Destroy (this.gameObject);

				}
			}
			if (target.tag.Equals ("Coin")) {
				if (Vector3.Distance (transform.position, target.transform.position) <= GameOptions.options.getGameSpeed () + 0.5f) {
					target.SetActive (false);
					Destroy (target.gameObject);
					GameOptions.options.addCoinsToCollection (1);
					//GameObject.FindGameObjectWithTag ("CoinsText").GetComponent<Text> ().text = "Coins: " + GameOptions.options.getCoinsCollected ();
				}
			}
		}
	}

	void FixedUpdate() {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && transform.position.x >= -0.5f && !isMovingLeft && !isMovingRight) {
			prevPosXLeft = Mathf.Round(transform.position.x);
			prevPosY = Mathf.Round(transform.position.y);
			startPosition = transform.position;
			speed = GameOptions.options.getGameSpeed ();
			isMovingLeft = true;
			startTime = Time.time;
			//transform.Translate(new Vector3 (-1.0f, 0.0f, 0.0f));
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && transform.position.x <= 0.5f && !isMovingLeft && !isMovingRight) {
			prevPosXRight = Mathf.Round(transform.position.x);
			prevPosY = Mathf.Round(transform.position.y);
			startPosition = transform.position;
			speed = GameOptions.options.getGameSpeed ();
			isMovingRight = true;
			startTime = Time.time;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && !isJumping) {
			//transform.position = transform.position + new Vector3 (transform.position.x, transform.position.y + 0.01f, transform.position.z);
			//GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0.0f, 1.0f, 0.0f) * 200.0f);
			isJumping = true;	
		}

		if (Input.GetKeyDown (KeyCode.Space) && !GameOptions.options.getGameStarted()) {
			GameOptions.options.setGameStarted (true);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Road") {
			//Debug.Log ("Collides with Ground");
			isJumping = false;
		}
		if (other.gameObject.tag == "Obstacle1") {
			//Debug.Log ("Collides with Obstacle1");
		}
	}
}
