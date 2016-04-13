using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	private bool isOnGround;
	// Use this for initialization
	void Start () {
		this.transform.SetParent (GameObject.Find ("Coins").transform);
		isOnGround = false;
	}

	// Update is called once per frame
	void Update () {
		if (isOnGround) {
			transform.Translate (0.0f, -GameOptions.options.getGameSpeed (), 0.0f);
			transform.Rotate (new Vector3 (0, -15, 0));
		}

		if (transform.position.z < -10.0f /*|| /*transform.position.y > 0.25f ||*/ ) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}

		if (transform.position.y < 0.1f) {
			transform.position = new Vector3 (transform.position.x, 0.1f, transform.position.z);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Road") {
			GetComponent<Collider> ().isTrigger = false;
			isOnGround = true;
		}  else if (other.gameObject.tag.StartsWith("Obstacle")) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}
	}
}