using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour {
	public static GameOptions options;
	private float gameSpeed = 0.2f;
	private float speedChange = 0.0002f;
	private float maxSpeed = 1.5f;
	private float shieldTimeFinish = 0.0f;
	private float magnetTimeFinish = 0.0f;
	private float speedNow = 0.0f;
	private float speedTimeFinish = 0.0f;
	private int frameCount = 0;
	private int frameChange = 120;
	private int coinDistance = 5;
	private int coinsCollected = 0;
	private int coinsThisRun = 0;
	private bool gameStarted = false;
	private bool shieldOn = false;
	private bool magnetOn = false;
	private bool speedOn = false;

	// Use this for initialization
	void Awake () {
		if (options == null) {
			DontDestroyOnLoad (this.gameObject);
			options = this;
			this.coinsCollected = PlayerPrefs.GetInt ("coins", 1);
		} else if (options != this) {
			Destroy (this.gameObject);
		}
	}

	void Start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name.Equals ("Game")) {
			GameObject.FindGameObjectWithTag ("CoinsText").GetComponent<Text> ().text = "Coins: " + coinsThisRun;
		} else if (SceneManager.GetActiveScene ().name.Equals ("MainMenu")) {
			GameObject.FindGameObjectWithTag ("CoinsCollectedText").GetComponent<Text> ().text = "Coins: " + coinsCollected;
		}
		if (gameStarted) {
			frameCount++;

			if (gameStarted && gameSpeed < maxSpeed) {
				//if (frameCount % frameChange == 0) {
				if (!this.speedOn) {
					gameSpeed = gameSpeed + speedChange;
				}
				
					//Debug.Log ("Speed = " + gameSpeed);
				//}
			}
		}

		if (this.speedOn) {
			if (Time.time > this.speedTimeFinish) {
				this.gameSpeed = this.speedNow;
				this.speedOn = false;
			}
		}

		if (this.shieldOn) {
			if (Time.time > this.shieldTimeFinish) {
				this.stopShieldOn ();
			}
		}

		Debug.Log("Speed = " + this.gameSpeed + " " + this.speedNow + " Shield is " + this.shieldOn);

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
		PlayerPrefs.SetInt ("coins", this.coinsCollected);
		PlayerPrefs.Save ();
	}

	public int getCoinsThisRun() {
		return this.coinsThisRun;
	}

	public void addCoinsToThisRun(int coins) {
		this.coinsThisRun += coins;
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

	public bool isSpeedOn() {
		return this.speedOn;
	}

	public void startSpeedOn() {
		this.speedOn = true;
		this.speedNow = this.gameSpeed;
		this.speedTimeFinish = Time.time + (5 * PlayerPrefs.GetInt ("velocityLevel", 1));
		this.gameSpeed = this.gameSpeed + (0.2f * PlayerPrefs.GetInt ("velocityLevel", 1));
	}

	public bool isShieldOn() {
		return this.shieldOn;
	}

	public void startShieldOn() {
		this.shieldOn = true;
		this.shieldTimeFinish = Time.time + (10 * PlayerPrefs.GetInt ("shieldLevel", 1));
	}

	public void stopShieldOn() {
		GameObject.FindGameObjectWithTag("ShieldSign").GetComponent<Renderer>().enabled = false;
		this.shieldOn = false;
	}
}
