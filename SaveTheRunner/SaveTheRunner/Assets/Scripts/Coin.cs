using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	private bool isOnGround;
	private bool isInSphere;
	private GameObject player;
	// Use this for initialization
	void Start () {
		this.transform.SetParent (GameObject.Find ("Coins").transform);
		this.player = GameObject.FindGameObjectWithTag ("Player");
		isOnGround = false;
		isInSphere = false;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.z < -10.0f /*|| /*transform.position.y > 0.25f ||*/ ) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}

		if (transform.position.y < 0.1f) {
			transform.position = new Vector3 (transform.position.x, 0.1f, transform.position.z);
		}

		if (isOnGround) {
			if (GameOptions.options.isMagnetOn ()) {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, 2.0f *  GameOptions.options.getGameSpeed ());
				//Debug.Log ("apoelin");
				return;
			}

			transform.Translate (0.0f, -GameOptions.options.getGameSpeed (), 0.0f);
			transform.Rotate (new Vector3 (0, -15, 0));
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals("Road")) {
			GetComponent<Collider> ().isTrigger = false;
			isOnGround = true;
		}  else if (other.gameObject.tag.StartsWith("Obstacle")) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		} else if (other.gameObject.tag.Equals("MagnetSphere")) {
			//Debug.Log ("Is in sphere");
			isOnGround = true;
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag.Equals ("Player")) {
			
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}
	}

	void OnDestroy() {
		
	}
}