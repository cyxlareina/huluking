using UnityEngine;
using System.Collections;

public class getBridgeRotation : MonoBehaviour {
	public GameObject bullet_shot_rotation;
	// Use this for initialization
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "bridge") {
			bullet_shot_rotation.transform.rotation = other.gameObject.transform.rotation ;
		}
	}
}
