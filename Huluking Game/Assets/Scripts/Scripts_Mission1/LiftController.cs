using UnityEngine;
using System.Collections;

public class LiftController : MonoBehaviour {

	private float speed = 3f;
	private bool direction = false;
	private bool startFlag = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (!startFlag) {
			return;
		}
		// up
		if (!direction) {
			if (transform.position.y >= 16) {
				direction = true;
			} else {
				transform.Translate (Vector3.up * Time.deltaTime * speed);
			}
		} else {
			if (transform.position.y <= 0) {
				direction = false;
			} else {
				transform.Translate (Vector3.down * Time.deltaTime * speed);
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		startFlag = true;
	}
}
