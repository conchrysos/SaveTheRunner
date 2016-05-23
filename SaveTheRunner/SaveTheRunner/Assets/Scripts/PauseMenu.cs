using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private bool settings = false;
	private bool musicPlays = false; 
	private bool soundsPlays = false;
	private GameObject sounds;
	private GameObject musicOn;
	private GameObject musicOff;
	private GameObject camera;
	private GameObject pauseButton;

	// Use this for initialization
	void Start () {
		musicOn = GameObject.FindGameObjectWithTag ("MusicOn");
		musicOff = GameObject.FindGameObjectWithTag ("MusicOff");
		sounds = GameObject.FindGameObjectWithTag ("SoundsButton");
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		pauseButton = GameObject.FindGameObjectWithTag ("PauseButton");
		musicPlays = (PlayerPrefs.GetInt ("sound", 1) == 1) ? true : false;
		musicOff.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (!GameOptions.options.isGameOver ()) {
				this.pauseGame ();
			}
		}
	}

	public void pauseGame() {
		GameOptions.options.pauseGame();
		pauseButton.SetActive (!GameOptions.options.isGamePaused());
	}

	public void resumeGame() {
		GameOptions.options.resumeGame();
		pauseButton.SetActive (true);
	}

	public void restartLevel() {
		GameOptions.options.restartLevel();
	}

	public void goHome() {
		GameOptions.options.goHome();
	}

	public void exitGame() {
		GameOptions.options.exitGame();
	}

	public void showSettings() {
		if (!settings) {
			settings = true;
		} else {
			settings = false;
		}

	}

	public void playSounds() {

	}

	public void playMusic(bool on) {
		if (!on) {
			musicPlays = true;
			PlayerPrefs.SetInt ("sound", 1);
			camera.GetComponent<AudioSource> ().Play ();
			musicOn.SetActive(true);
			musicOff.SetActive(false);
		} else {
			musicPlays = false;
			PlayerPrefs.SetInt ("sound", 0);
			camera.GetComponent<AudioSource> ().Stop ();
			musicOn.SetActive(false);
			musicOff.SetActive(true);
		}
	}
}
