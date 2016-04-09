using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private Transform player;
	private Animation anim;
	private int sound;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		//start of Marios code
		sound = PlayerPrefs.GetInt ("sound", 1);

		if (sound == 1) {
			Camera.main.GetComponent <AudioSource> ().Play ();
		} 

		else {
			Camera.main.GetComponent <AudioSource> ().Stop ();
		}
		//end of Marios code
	}
	
	// LateUpdate is called once per frame usually after Update for camera adjustment
	void LateUpdate () {
		transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
}
