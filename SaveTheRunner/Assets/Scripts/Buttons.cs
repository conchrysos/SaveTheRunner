using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
	int sound; //0 is off and 1 is on
	public GameObject soundOnButton;
	public GameObject soundOffButton;

	// Use this for initialization
	void Start () {
		sound = PlayerPrefs.GetInt ("sound", 1);

		if (sound == 1) {
			Camera.main.GetComponent <AudioSource> ().Play ();
			soundOffButton.SetActive (true);
			soundOnButton.SetActive (false);
		} 

		else {
			Camera.main.GetComponent <AudioSource> ().Stop ();
			soundOffButton.SetActive (false);
			soundOnButton.SetActive (true);
		}


	}

	public void LoadGame(){	
		SceneManager.LoadScene ("Game");	
	}

	public void Exit(){
		Application.Quit ();
	}

	public void SoundOn(){
		PlayerPrefs.SetInt ("sound", 1);
		PlayerPrefs.Save ();
	}

	public void SoundOff(){
		PlayerPrefs.SetInt ("sound", 0);
		PlayerPrefs.Save ();
	}


}
