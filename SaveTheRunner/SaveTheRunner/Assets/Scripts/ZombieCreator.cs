using UnityEngine;
using System.Collections;

public class ZombieCreator : MonoBehaviour {
	private int randInt;
	private int randObject;
	private int zombieNo;
	private int no;
	public GameObject[] zombies;

	// Use this for initialization
	void Start () {
		randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
		zombieNo = 0;
		no = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted () || GameOptions.options.isGamePaused() || GameOptions.options.isGameOver()) {
			return;
		}
		if (no == randInt) {
			randObject = (int)Mathf.Round(Random.Range (0.0f, zombies.Length - 1));
			Object obstacle = Instantiate (zombies[randObject], new Vector3 (transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
			obstacle.name = "Zombie" + randObject.ToString () + "-" + zombieNo.ToString ();
			randInt = (int)Mathf.Round(Random.Range (200.0f, 500.0f));
			//Debug.Log ("Rand = " + randInt);
			no = 0;
			zombieNo++;
		}
		no++;
	}
}
