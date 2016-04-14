using UnityEngine;
using System.Collections;

public class HouseRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (transform.rotation.y == 180f) {
			transform.Rotate (new Vector3 (0f, 180f, 0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
