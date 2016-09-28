using UnityEngine;
using System.Collections;

public class kill_obstract : MonoBehaviour {
	public int life;
	// Use this for initialization
	void Start () {
		if(life == 0)
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
