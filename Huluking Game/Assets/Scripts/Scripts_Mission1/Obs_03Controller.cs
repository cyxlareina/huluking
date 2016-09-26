using UnityEngine;
using System.Collections;

public class Obs_03Controller : MonoBehaviour {

	public float speed;

	private bool flag;

	// Use this for initialization
	void Start () {
		flag = true;
	}
	
	// Update is called once per frame
	void Update () {
		// up
		if (flag) {
			if (transform.position.y >= 2) {
				flag = false;
				transform.Translate (Vector3.down * Time.deltaTime * speed);
			} else {
				transform.Translate (Vector3.up * Time.deltaTime * speed);
			}
		// down
		} else {
			if (transform.position.y <= -3) {
				flag = true;
				transform.Translate (Vector3.up * Time.deltaTime * speed);
			} else {
				transform.Translate (Vector3.down * Time.deltaTime * speed);
			}
		}
	}
}
