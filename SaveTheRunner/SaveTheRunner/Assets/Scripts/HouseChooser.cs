using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HouseChooser : MonoBehaviour {
	public HouseRotation houseRotation;
	public GameObject[] houses;
	private int randObject, i;

	// Use this for initialization
	void Start () {
		randObject = (int)Mathf.Round(Random.Range (0.0f, houses.Length - 1));
		i = 0;

		GameObject house = Instantiate (houses [randObject], new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as GameObject;
		if (transform.parent.name.StartsWith("HouseLeft")) {
			house.transform.Rotate (new Vector3 (0f, 180f, 0f));
		}
		//house.transform.rotation= Quaternion.EulerAngles(0,0,0);
		house.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		house.transform.SetParent (this.transform.parent);
		//house.AddComponent <Type.GetType("HouseRotation")>();
		house.name = "house-" + house.name.Substring (17).Split ('(') [0];



	}
	
	// Update is called once per frame
	void Update () {
		if (i == 1)
			return;
		//Debug.Log (this.transform.parent.name);
//		if (this.transform.parent.transform.rotation.y == 180f) {
//			//this.transform.Rotate (new Vector3 (0f, 180f, 0f));
//
			
//
//		} else {
//			Object house = Instantiate (houses [randObject], new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
//			((GameObject)house).transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
//			((GameObject)house).transform.SetParent (this.transform.parent);
//			house.name = "house-" + house.name.Substring (17).Split ('(') [0];
//		}

		i++;
	}
}
