﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,0 );
	}



}
