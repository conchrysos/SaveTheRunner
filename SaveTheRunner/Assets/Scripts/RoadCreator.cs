using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {
	private int noRoads = 0;
	public Transform roadPrefab;
	private bool isCreating;

	// Use this for initialization
	void Start () {
		isCreating = false;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject road = GameObject.FindGameObjectWithTag ("Ground");
		if (road.transform.position.z < -15.0f && !isCreating) {
			Instantiate (roadPrefab, new Vector3 (0, 0, road.transform.position.z + 50.0f - road.GetComponent<Road>().getSpeed()), Quaternion.identity);
			isCreating = true;
		}
	}
}
