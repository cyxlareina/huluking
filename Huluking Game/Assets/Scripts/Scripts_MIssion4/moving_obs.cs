using UnityEngine;
using System.Collections;

public class moving_obs : MonoBehaviour {
	private int move_right;
	public int cur_pos;
	public int moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cur_pos == 30)
			move_right = 1;
		if (cur_pos == -30)
			move_right = 0;
		if (move_right == 1) {
			gameObject.transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
			cur_pos--;
		} else {
			gameObject.transform.Translate (-Vector3.right * Time.deltaTime * moveSpeed);
			cur_pos++;
		}
	}
}
