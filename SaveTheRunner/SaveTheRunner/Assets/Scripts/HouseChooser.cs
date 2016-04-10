using UnityEngine;
using System.Collections;

public class HouseChooser : MonoBehaviour {
	public GameObject[] houses;
	private int randObject;

	// Use this for initialization
	void Start () {
		randObject = (int)Mathf.Round(Random.Range (0.0f, houses.Length - 1));
		Object house = Instantiate (houses[randObject], new Vector3 (5.0f, 0.04f, 0.0f), Quaternion.identity);
		((GameObject)house).transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		((GameObject)house).transform.SetParent (this.transform.parent);
		house.name = "house-" + house.name.Substring(17).Split('(')[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
