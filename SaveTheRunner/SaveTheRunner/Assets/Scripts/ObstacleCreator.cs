using UnityEngine;
using System.Collections;
//using UnityEditor;

public class ObstacleCreator : MonoBehaviour {
	private int randInt;
	private int randObject;
	private int obstacleNo;
	private int no;
	public GameObject[] obstacles;

	// Use this for initialization
	void Start () {
		randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
		obstacleNo = 0;
		no = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted () || GameOptions.options.isGamePaused() || GameOptions.options.isGameOver()) {
			return;
		}
		if (no == randInt) {
			randObject = (int)Mathf.Round(Random.Range (0.0f, obstacles.Length - 1));
			Object obstacle = Instantiate (obstacles[randObject], new Vector3 (transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
			if (randObject == 1) {
				((GameObject) obstacle).transform.Rotate(new Vector3( -90f, 0f, 0f));
			}
			obstacle.name = "Obstacle" + randObject.ToString () + "-" + obstacleNo.ToString ();
			randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
			//Debug.Log ("Rand = " + randInt);
			no = 0;
			obstacleNo++;
		}
		no++;
	}
}
