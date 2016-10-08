using UnityEngine;
using System.Collections;

public class bullet_coin : MonoBehaviour {
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "bullet") {
			AudioSource audio = gameObject.GetComponent<AudioSource> ();
			Debug.Log ("herehrerer");
			gameObject.GetComponent<Renderer> ().enabled = false;
			gameObject.GetComponent<Collider> ().enabled = false;
			audio.Play ();
			Destroy (other.gameObject);
			Destroy (gameObject, 1.5f);
		}
	}
}
