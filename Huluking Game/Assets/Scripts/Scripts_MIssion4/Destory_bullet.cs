using UnityEngine;
using System.Collections;

public class Destory_bullet : MonoBehaviour {
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "bullet") {
			Destroy (other.gameObject);
		}
	}
}
