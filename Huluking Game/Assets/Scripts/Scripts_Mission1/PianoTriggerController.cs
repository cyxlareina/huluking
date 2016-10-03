using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PianoTriggerController : MonoBehaviour {

	public GameObject bridge;

	void Update ()
	{
		transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			AudioSource audio = bridge.GetComponent<AudioSource> ();
			Animation animation = bridge.GetComponent<Animation> ();
			if (audio != null) {
				audio.Play ();
			}
			if (animation != null) {
				animation.Play ();
			}
			Destroy (gameObject);
		}
	}
}
