using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private Transform player;
	private Animation anim;
	public AudioClip musicSound;
	public AudioClip gameOverSound;
	private int music;
	private bool gameOver;

	// Use this for initialization
	void Start () {
		this.GetComponent<AudioSource> ().clip = musicSound;
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		//start of Marios code
		music = PlayerPrefs.GetInt ("music", 1);

		if (music == 1) {
			Camera.main.GetComponent <AudioSource> ().Play ();
		} 

		else {
			Camera.main.GetComponent <AudioSource> ().Stop ();
		}
		//end of Marios code

		gameOver = false;
	}
	
	// LateUpdate is called once per frame usually after Update for camera adjustment
	void LateUpdate () {
		transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
		if (GameOptions.options.isGameOver () && !gameOver && (PlayerPrefs.GetInt("music", 1) == 1)) {
			this.GetComponent<AudioSource> ().clip = gameOverSound;
			this.GetComponent<AudioSource> ().loop = false;
			this.GetComponent<AudioSource> ().playOnAwake = false;
			this.GetComponent<AudioSource> ().Play ();
			gameOver = true;
		}
	}
}
