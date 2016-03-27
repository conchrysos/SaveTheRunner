using UnityEngine;
using System.Collections;

public class GameOptions : MonoBehaviour {
	public static GameOptions options;
	private float gameSpeed = 0.0f;
	private float speedChange = 0.02f;
	private float maxSpeed = 1.5f;
	private int frameCount = 0;
	private int frameChange = 120;

	// Use this for initialization
	void Awake () {
		if (options == null) {
			DontDestroyOnLoad (this.gameObject);
			options = this;
		} else if (options != this) {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		frameCount++;
		//Debug.Log ("Enters Update with frameCount " + frameCount);
		//if
		if (frameCount % frameChange == 0) {
			gameSpeed = gameSpeed + speedChange;
			Debug.Log ("Speed = " + gameSpeed);
		}
	}

	public float getGameSpeed() {
		return this.gameSpeed;
	}

	public void setGameSpeed(float speed) {
		this.gameSpeed = speed;
	}
}
