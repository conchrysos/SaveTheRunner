﻿using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f, 0.0f, -speed);
	}

	public float getSpeed() {
		return speed;
	}
}
