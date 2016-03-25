using UnityEngine;
using System.Collections;

public class ObstacleCreator : MonoBehaviour {
	private int randInt;
	private int obstacleNo;
	private int no;
	public Transform obstacle1;

	// Use this for initialization
	void Start () {
		randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
		//Debug.Log ("Rand = " + randInt);
		obstacleNo = 0;
		no = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (no == randInt) {
			Object obstacle = Instantiate (obstacle1, new Vector3 (transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
			obstacle.name = "Obstacle-" + obstacleNo.ToString ();
			randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
			//Debug.Log ("Rand = " + randInt);
			no = 0;
			obstacleNo++;
		}
		no++;
	}
}
