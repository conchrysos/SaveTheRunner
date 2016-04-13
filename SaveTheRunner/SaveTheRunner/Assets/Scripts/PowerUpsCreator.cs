using UnityEngine;
using System.Collections;

public class PowerUpsCreator : MonoBehaviour {


	private int randInt;
	private int randObject;
	private int powerUpNo;
	private int no;
	public GameObject[] powerUps;

	// Use this for initialization
	void Start () {
		randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
		powerUpNo = 0;
		no = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}
		if (no == randInt) {
			randObject = (int)Mathf.Round(Random.Range (0.0f, powerUps.Length - 1));
			Object powerUp = Instantiate (powerUps[randObject], new Vector3 (transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
			powerUp.name = "PowerUp" + randObject.ToString () + "-" + powerUpNo.ToString ();
			randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
			//Debug.Log ("Rand = " + randInt);
			no = 0;
			powerUpNo++;
		}
		no++;
	}
}
