using UnityEngine;
using System.Collections;

public class get_hit_bridge_move : MonoBehaviour {
	public GameObject bridge;
	public int go_down;
	public int cur_pos;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter (Collider other)
	{
		Destroy (other.gameObject);
		if (cur_pos == 3)
			go_down = 1;
		if (cur_pos == 0)
			go_down = 0;
		
		if (go_down == 1) {
			bridge.transform.Translate (Vector3.down * Time.deltaTime * 60);
			cur_pos--;
		} else {
			bridge.transform.Translate (Vector3.up * Time.deltaTime * 60);
			cur_pos++;
		}
	}
}
