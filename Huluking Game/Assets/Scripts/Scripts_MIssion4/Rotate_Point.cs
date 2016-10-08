using UnityEngine;
using System.Collections;

public class Rotate_Point : MonoBehaviour {
	private int life;
	public GameObject left;
	public GameObject right;
	// Use this for initialization
	void Start () {
		life = 1;
	}

	// Update is called once per frame
	void Update () {
		if (life == 0) {
			Destroy (gameObject);
			Destroy (left);
			Destroy (right);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "bullet") {
			Destroy (other.gameObject);
			life--;
		}
	}
}
