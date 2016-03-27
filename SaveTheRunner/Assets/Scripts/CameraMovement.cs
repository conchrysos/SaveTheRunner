﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
}
