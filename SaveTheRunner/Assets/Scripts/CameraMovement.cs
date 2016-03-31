using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private Transform player;
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
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
}
