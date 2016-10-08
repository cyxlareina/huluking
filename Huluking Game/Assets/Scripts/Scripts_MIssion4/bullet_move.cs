using UnityEngine;
using System.Collections;

public class bullet_move : MonoBehaviour {
	public float speed;
	private int count = 0;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void Update(){
		if (count == 90) {
			Destroy(gameObject);
		}
		count++;
	}
}
