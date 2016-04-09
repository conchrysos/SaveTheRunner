using UnityEngine;
using System.Collections;

public class Positioner : MonoBehaviour {
	private bool move;

	// Use this for initialization
	void Start () {
		move = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}
		if (move) {
			transform.Translate (0.0f, 0.0f, -GameOptions.options.getGameSpeed ());
			if (Mathf.Abs (transform.position.z) >= 1000.0f) {
				transform.position = Vector3.zero;
			}
		}
	}

	public void setMove(bool newMove) {
		this.move = newMove;
	}
}
