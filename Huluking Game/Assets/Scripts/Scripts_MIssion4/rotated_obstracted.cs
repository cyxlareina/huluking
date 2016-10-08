using UnityEngine;
using System.Collections;

public class rotated_obstracted : MonoBehaviour {
	public int rotateSpeed;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		var x = Time.deltaTime * rotateSpeed;
		transform.Rotate (0,x,0);
	}
}
