﻿using UnityEngine;
using System.Collections;

public class RotateController : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);
	}
}