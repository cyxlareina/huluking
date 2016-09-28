using UnityEngine;
using System.Collections;

public class kill_obstract : MonoBehaviour {
	private int life;
	// Use this for initialization
	void Start () {
		life = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if (life == 0)
			Destroy (gameObject);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "bullet") {
			Destroy (other.gameObject);
			life--;
		}
	}
}
