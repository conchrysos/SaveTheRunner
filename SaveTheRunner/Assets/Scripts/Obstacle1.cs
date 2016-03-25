using UnityEngine;
using System.Collections;

public class Obstacle1 : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f, 0.0f, -speed);

		if (transform.position.z < -10.0f) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}
	}
}
