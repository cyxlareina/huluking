using UnityEngine;
using System.Collections;

public class kill_obstract : MonoBehaviour {
	public int life;
	private int max_life;
	private float init_blood_bar_x;
	private float init_blood_bar_y;
	public GameObject blood_bar;
	// Use this for initialization
	void Start () {
		if(life == 0)
			life = 4;
		max_life = life;
		init_blood_bar_x = blood_bar.transform.localScale.x;
		init_blood_bar_y = blood_bar.transform.localScale.y;
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

			blood_bar.transform.localScale = new Vector3(init_blood_bar_x * ((float)life / (float)max_life),init_blood_bar_y,1.0f);
		}
	}
}
