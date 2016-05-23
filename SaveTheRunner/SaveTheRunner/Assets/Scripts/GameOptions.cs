using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour {
	public static GameOptions options;
	private float gameSpeed = 0.2f;
	private float speedChange = 0.0002f;
	private float maxSpeed = 1.5f;
	private float currentSpeed = 0.0f;
	private float distanceCovered = 0.0f;
	private float gameScoreThisRun = 0.0f;
	private float gameScoreBest = 0.0f;
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
	private bool gamePaused = false;
	private bool gameOver = false;

	// Use this for initialization
	void Awake () {
		if (options == null) {
			DontDestroyOnLoad (this.gameObject);
			options = this;
			this.coinsCollected = PlayerPrefs.GetInt ("coins", 1);
			this.gameScoreBest = PlayerPrefs.GetFloat ("score", 1);
		} else if (options != this) {
			Destroy (this.gameObject);
		}
	}

	void Start() {
		this.coinsCollected = PlayerPrefs.GetInt ("coins", 1);
		this.gameScoreBest = PlayerPrefs.GetFloat ("score", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name.Equals ("Game")) {
			if (!this.gameOver && GameObject.FindGameObjectWithTag ("CoinsText") != null && GameObject.FindGameObjectWithTag ("DistanceText") != null) {
				GameObject.FindGameObjectWithTag ("CoinsText").GetComponent<Text> ().text = "Coins: " + this.coinsThisRun;
				GameObject.FindGameObjectWithTag ("DistanceText").GetComponent<Text> ().text = "Distance: " + this.distanceCovered;
			}
		} else if (SceneManager.GetActiveScene ().name.Equals ("MainMenu")) {
			GameObject.FindGameObjectWithTag ("CoinsCollectedText").GetComponent<Text> ().text = "Coins: " + this.coinsCollected;
			GameObject.FindGameObjectWithTag ("BestScoreText").GetComponent<Text> ().text = "Best Score: " + PlayerPrefs.GetFloat ("score", 1);
		}
		if (gameStarted) {
			frameCount++;

			if (this.gameOver != true) {
				if (!this.gamePaused) {
					if (gameStarted && gameSpeed < maxSpeed) {
						//if (frameCount % frameChange == 0) {
						if (!this.speedOn) {
							gameSpeed = gameSpeed + speedChange;

						}
						distanceCovered = distanceCovered + gameSpeed;
						//Debug.Log ("Distance = " + distanceCovered);
						//}
					}
				}
			}
		}

		if (this.speedOn) {
			if (Time.time > this.speedTimeFinish) {
				this.gameSpeed = this.speedNow;
				this.speedOn = false;
				GameObject.FindGameObjectWithTag("SpeedSign").GetComponent<Renderer>().enabled = false;
			}
		}

		if (this.shieldOn) {
			if (Time.time > this.shieldTimeFinish) {
				this.stopShieldOn ();
			}
		}

		if (this.magnetOn) {
			if (Time.time > this.magnetTimeFinish) {
				this.stopMagnetOn ();
			}
		}
		//Debug.Log("Speed = " + this.gameSpeed + " " + this.speedNow + " Shield is " + this.shieldOn);
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

	public float getGameScore() {
		this.gameScoreThisRun = this.distanceCovered + this.coinsThisRun;
		return this.gameScoreThisRun;
	}

	public float getBestScore() {
		this.gameScoreBest = (this.gameScoreBest > this.gameScoreThisRun) ? this.gameScoreBest : this.gameScoreThisRun;
		PlayerPrefs.SetFloat ("score", this.gameScoreBest);
		PlayerPrefs.Save ();
		return this.gameScoreBest;
	}

	public float getDistanceCovered(){
		return this.distanceCovered;
	}

	public void setGameStarted(bool start) {
		this.gameStarted = start;
	}

	public bool getGameStarted() {
		return this.gameStarted;
	}

	public bool isGameOver() {
		return this.gameOver;
	}

	public void endGame(){
		this.gameSpeed = 0.0f;
		GameObject.FindGameObjectWithTag ("GameOverMenu").GetComponent<Animator> ().Play ("gameOverPanel");
		GameObject.FindGameObjectWithTag ("CoinsEnd").GetComponent<Text> ().text = "Coins: " + this.getCoinsThisRun ();
		GameObject.FindGameObjectWithTag ("DistanceEnd").GetComponent<Text> ().text = "Distance: " + this.getDistanceCovered ();
		GameObject.FindGameObjectWithTag ("ScoreEnd").GetComponent<Text> ().text = "Score: " + this.getGameScore ();
		GameObject.FindGameObjectWithTag ("BestScoreEnd").GetComponent<Text> ().text = "Best Score: " + this.getBestScore ();
		GameObject.FindGameObjectWithTag ("DistanceText").SetActive (false);
		GameObject.FindGameObjectWithTag ("CoinsText").SetActive (false);
		GameObject.FindGameObjectWithTag ("PauseButton").SetActive (false);
		this.gameOver = true;
		Debug.Log ("GAME ENDED" + this.gameOver);
	}

	public bool isSpeedOn() {
		return this.speedOn;
	}

	public void startSpeedOn() {
		this.speedOn = true;
		this.speedNow = this.gameSpeed;
		this.speedTimeFinish = Time.time + (5 * PlayerPrefs.GetInt ("velocityLevel", 1));
		this.gameSpeed = this.gameSpeed + (0.2f * PlayerPrefs.GetInt ("velocityLevel", 1));
		GameObject.FindGameObjectWithTag("SpeedSign").GetComponent<Renderer>().enabled = true;
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

	public bool isMagnetOn() {
		return this.magnetOn;
	}

	public void startMagnetOn() {
		this.magnetOn = true;
		this.magnetTimeFinish = Time.time + (10 * PlayerPrefs.GetInt ("magnetLevel", 1));
	}

	public void stopMagnetOn() {
		GameObject.FindGameObjectWithTag("MagnetSign").GetComponent<Renderer>().enabled = false;
		this.magnetOn = false;
	}

	public void pauseGame() {
		if (!this.gamePaused) {
			GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<Animator> ().Play ("pausePanelDown");
			this.gamePaused = true;
			this.currentSpeed = this.gameSpeed;
			this.gameSpeed = 0.0f;
		} else {
			GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<Animator> ().Play ("pausePanelUp");
			this.gamePaused = false;
			this.gameSpeed = this.currentSpeed;
		}
	}

	public void resumeGame() {
		GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<Animator> ().Play ("pausePanelUp");
		this.gamePaused = false;
		this.gameSpeed = this.currentSpeed;
	}

	public void restartLevel() {
		gameSpeed = 0.2f;
		speedChange = 0.0002f;
		maxSpeed = 1.5f;
		currentSpeed = 0.0f;
		distanceCovered = 0.0f;
		gameScoreThisRun = 0.0f;
		gameScoreBest = PlayerPrefs.GetFloat ("score", 1);
		shieldTimeFinish = 0.0f;
		magnetTimeFinish = 0.0f;
		speedNow = 0.0f;
		speedTimeFinish = 0.0f;
		frameCount = 0;
		frameChange = 120;
		coinDistance = 5;
		coinsCollected = PlayerPrefs.GetInt ("coins", 1);
		coinsThisRun = 0;
		gameStarted = false;
		shieldOn = false;
		magnetOn = false;
		speedOn = false;
		gamePaused = false;
		gameOver = false;
		SceneManager.LoadScene (1);
	}

	public void goHome() {
		gameSpeed = 0.2f;
		speedChange = 0.0002f;
		maxSpeed = 1.5f;
		currentSpeed = 0.0f;
		distanceCovered = 0.0f;
		gameScoreThisRun = 0.0f;
		gameScoreBest = PlayerPrefs.GetFloat ("score", 1);
		shieldTimeFinish = 0.0f;
		magnetTimeFinish = 0.0f;
		speedNow = 0.0f;
		speedTimeFinish = 0.0f;
		frameCount = 0;
		frameChange = 120;
		coinDistance = 5;
		coinsCollected = PlayerPrefs.GetInt ("coins", 1);
		coinsThisRun = 0;
		gameStarted = false;
		shieldOn = false;
		magnetOn = false;
		speedOn = false;
		gamePaused = false;
		gameOver = false;
		SceneManager.LoadScene (0);
	}

	public bool isGamePaused() {
		return this.gamePaused;
	}

	public void setGamePause(bool pause){
		this.gamePaused = pause;
	}

	public void exitGame(){
		Application.Quit();
	}
}
