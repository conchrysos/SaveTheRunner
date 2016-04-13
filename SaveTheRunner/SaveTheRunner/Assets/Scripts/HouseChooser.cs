using UnityEngine;
using System.Collections;

public class HouseChooser : MonoBehaviour {
	public GameObject[] houses;
	private int randObject;

	// Use this for initialization
	void Start () {
		randObject = (int)Mathf.Round(Random.Range (0.0f, houses.Length - 1));


		Debug.Log (this.transform.parent.name);
		if (this.transform.parent.transform.rotation.y == 180f) {
			this.transform.Rotate (new Vector3 (0f, 180f, 0f));
			Object house = Instantiate (houses [randObject], new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			//((GameObject)house).transform.Rotate (new Vector3 (0f, 0f, 0f));
			((GameObject)house).transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			((GameObject)house).transform.SetParent (this.transform.parent);
			house.name = "house-" + house.name.Substring (17).Split ('(') [0];
		} else {
			Object house = Instantiate (houses [randObject], new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			((GameObject)house).transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			((GameObject)house).transform.SetParent (this.transform.parent);
			house.name = "house-" + house.name.Substring (17).Split ('(') [0];
		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
