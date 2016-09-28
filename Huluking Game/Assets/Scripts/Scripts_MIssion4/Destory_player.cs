using UnityEngine;
using System.Collections;

public class Destory_player : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
		}
	}
}
