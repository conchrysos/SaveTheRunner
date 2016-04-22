using UnityEngine;
using System.Collections;
//using UnityEditor;

public class HouseCreator : MonoBehaviour {
	public GameObject house;
	public GameObject positioner;
	private int houseNo;

	// Use this for initialization
	void Start () {
		houseNo = 1;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if(GameObject.FindGameObjectsWithTag("HouseWithGarden").Length < 160){	
			Vector3 pos = new Vector3 (this.transform.position.x, this.transform.position.y, GameObject.Find ("HouseRight-" + (houseNo - 1).ToString ()).transform.position.z + 3f);
			GameObject house1 = Instantiate (house, pos, /*((GameObject)Selection.activeObject)*/Quaternion.identity) as GameObject;
			house1.transform.position = new Vector3 (house1.transform.position.x - 0.05f, house1.transform.position.y, house1.transform.position.z);
			house1.name = "HouseRight-" + houseNo.ToString ();
			GameObject house2 = Instantiate (house, pos, /*((GameObject)Selection.activeObject)*/Quaternion.identity) as GameObject;
			house2.transform.position = new Vector3 (0.05f, house2.transform.position.y, house2.transform.position.z);
			house2.name = "HouseLeft-" + houseNo.ToString ();
			house2.transform.Rotate (new Vector3 (0f, 180f, 0f));
			houseNo++;
		}
	}
}
