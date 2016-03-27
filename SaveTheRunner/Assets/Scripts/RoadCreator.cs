using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {
	public Transform roadPrefab;
	private bool isCreating;
	private int roadNo;

	// Use this for initialization
	void Start () {
		isCreating = false;
		roadNo = 0;
		Object road1 = Instantiate (roadPrefab, new Vector3 (0, 0, 15), Quaternion.identity);
		road1.name = "Ground-" + roadNo.ToString ();
		Object road2 = Instantiate (roadPrefab, new Vector3 (0, 0, roadPrefab.transform.position.z + 50.0f), Quaternion.identity);
		roadNo++;
		road2.name = "Ground-" + roadNo.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}

		GameObject road = GameObject.Find("Ground-" + (roadNo - 1).ToString());
		int no = int.Parse (road.name.Split (new char[] { '-'}) [1].ToString());

		// Creates 2 instances of road
		if (no % 3 == 0 && road.transform.position.z < 0.0f  && !isCreating) {
			Object newRoad = Instantiate (roadPrefab, new Vector3 (0, 0, road.transform.position.z + 100.0f - GameOptions.options.getGameSpeed()), Quaternion.identity);
			roadNo++;
			newRoad.name = "Ground-" + roadNo.ToString ();
			newRoad = Instantiate (roadPrefab, new Vector3 (0, 0, road.transform.position.z + 150.0f - GameOptions.options.getGameSpeed()), Quaternion.identity);
			roadNo++;
			newRoad.name = "Ground-" + roadNo.ToString ();
			newRoad = Instantiate (roadPrefab, new Vector3 (0, 0, road.transform.position.z + 200.0f - GameOptions.options.getGameSpeed()), Quaternion.identity);
			roadNo++;
			newRoad.name = "Ground-" + roadNo.ToString ();
			isCreating = true;
		} else {
			isCreating = false;
		}
	}
}
