using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.SetParent (GameObject.Find ("Roads").transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}
		if(transform.rotation.y == 90.0f * Mathf.Deg2Rad){
			transform.Translate (-GameOptions.options.getGameSpeed(), 0.0f, 0.0f);
		} else {
			transform.Translate (0.0f, 0.0f, -GameOptions.options.getGameSpeed());
		}

		if (transform.position.z < -35.0f) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}
	}
}
