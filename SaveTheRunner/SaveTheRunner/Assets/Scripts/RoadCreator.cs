using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {
	public GameObject road;
	private int roadNo;

	// Use this for initialization
	void Start () {
		roadNo = 1;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if(GameObject.FindGameObjectsWithTag("Road").Length < 6){	
			Vector3 pos = new Vector3 (this.transform.position.x, this.transform.position.y, GameObject.Find ("Road-" + (roadNo - 1).ToString ()).transform.position.z + 50f);
			GameObject roadObj = Instantiate (road, pos, /*((GameObject)Selection.activeObject)*/Quaternion.identity) as GameObject;
			roadObj.name = "Road-" + roadNo.ToString ();
			roadNo++;
		}
	}
}
