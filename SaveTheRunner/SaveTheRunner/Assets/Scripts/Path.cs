using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {
	public Material[] paths;
	private int randObject;

	// Use this for initialization
	void Start () {
		randObject = (int)Mathf.Round(Random.Range (0.0f, paths.Length - 1));
		GetComponent<Renderer> ().material = paths [randObject];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
