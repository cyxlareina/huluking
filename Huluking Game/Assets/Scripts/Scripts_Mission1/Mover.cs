using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start ()
	{
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity = transform.forward * speed;
		Destroy (gameObject, 3.0f);
	}

}
