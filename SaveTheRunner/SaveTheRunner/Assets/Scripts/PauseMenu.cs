using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private bool settings = false;
	private bool musicPlays = false; 
	private bool soundsPlays = false;
	private GameObject musicOn;
	private GameObject musicOff;
	private GameObject soundsOn;
	private GameObject soundsOff;
	private GameObject camera;
	private GameObject pauseButton;

	// Use this for initialization
	void Start () {
		musicOn = GameObject.FindGameObjectWithTag ("MusicOn");
		musicOff = GameObject.FindGameObjectWithTag ("MusicOff");
		soundsOn = GameObject.FindGameObjectWithTag ("SoundsOn");
		soundsOff = GameObject.FindGameObjectWithTag ("SoundsOff");
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		pauseButton = GameObject.FindGameObjectWithTag ("PauseButton");
		musicPlays = (PlayerPrefs.GetInt ("music", 1) == 1) ? true : false;

		if (PlayerPrefs.GetInt ("music", 1) == 1) {
			musicOn.SetActive (true);
			musicOff.SetActive (false);
		} else {
			musicOn.SetActive(false);
			musicOff.SetActive(true);
		}

		if (PlayerPrefs.GetInt ("sound", 1) == 1) {
			soundsOn.SetActive (true);
			soundsOff.SetActive (false);
		} else {
			soundsOn.SetActive(false);
			soundsOff.SetActive(true);
		}
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

	public void playMusic(bool on) {
		if (!on) {
			musicPlays = true;
			PlayerPrefs.SetInt ("music", 1);
			PlayerPrefs.Save ();
			camera.GetComponent<AudioSource> ().Play ();
			musicOn.SetActive(true);
			musicOff.SetActive(false);
		} else {
			musicPlays = false;
			PlayerPrefs.SetInt ("music", 0);
			PlayerPrefs.Save ();
			camera.GetComponent<AudioSource> ().Stop ();
			musicOn.SetActive(false);
			musicOff.SetActive(true);
		}
	}

	public void playSounds(bool on) {
		if (!on) {
			soundsPlays = true;
			PlayerPrefs.SetInt ("sound", 1);
			PlayerPrefs.Save ();
			soundsOn.SetActive(true);
			soundsOff.SetActive(false);
		} else {
			soundsPlays = false;
			PlayerPrefs.SetInt ("sound", 0);
			PlayerPrefs.Save ();
			soundsOn.SetActive(false);
			soundsOff.SetActive(true);
		}
	}
}
