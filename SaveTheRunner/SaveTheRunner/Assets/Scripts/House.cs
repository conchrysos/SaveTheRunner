using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.SetParent (GameObject.Find ("Houses").transform);
	}

	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}
		if (transform.rotation.y == 0f) {
			transform.Translate (0.0f, 0.0f, -GameOptions.options.getGameSpeed ());
		} else {
			transform.Translate (0.0f, 0.0f, GameOptions.options.getGameSpeed ());
		}

		if (transform.position.z < -10.0f) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}
	}
}

