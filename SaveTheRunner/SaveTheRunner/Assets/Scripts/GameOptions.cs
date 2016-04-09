using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour {
	public static GameOptions options;
	private float gameSpeed = 0.2f;
	private float speedChange = 0.0002f;
	private float maxSpeed = 1.5f;
	private int frameCount = 0;
	private int frameChange = 120;
	private int coinDistance = 5;
	private int coinsCollected = 0;
	private bool gameStarted = false;

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
		GameObject.FindGameObjectWithTag ("CoinsText").GetComponent<Text> ().text = "Coins: " + coinsCollected;
		if (gameStarted) {
			frameCount++;
			if (gameStarted && gameSpeed < maxSpeed) {
				//if (frameCount % frameChange == 0) {
				gameSpeed = /*(float)System.Math.Round(*/gameSpeed + speedChange/*, 2)*/;
					//Debug.Log ("Speed = " + gameSpeed);
				//}
			}
		}
	}

	public float getGameSpeed() {
		return this.gameSpeed;
	}

	public void setGameSpeed(float speed) {
		this.gameSpeed = speed;
	}

	public float getMaxGameSpeed() {
		return this.maxSpeed;
	}

	public void setMaxGameSpeed(float speed) {
		this.maxSpeed = speed;
	}

	public int getCoinDistance() {
		return this.coinDistance;
	}

	public void setCoinDistance(int distance) {
		this.coinDistance = distance;
	}

	public int getCoinsCollected() {
		return this.coinsCollected;
	}

	public void addCoinsToCollection(int coins) {
		this.coinsCollected += coins;
	}

	public void removeCoinsFromCollection(int coins) {
		this.coinsCollected -= coins;
	}

	public void setGameStarted(bool start) {
		this.gameStarted = start;
	}

	public bool getGameStarted() {
		return this.gameStarted;
	}
}
