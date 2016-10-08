using UnityEngine;
using System.Collections;

public class rotate_bridge : MonoBehaviour {
	public GameObject bridge;
	public GameObject bridge1;
	public int rotate_degree;
	private GameObject player;
	private int flag;
	private int round;

	void Start () {
		flag = 0;
		round = 0;
	}

	void Update () {
		if (flag == 1){
			var x =Time.deltaTime * rotate_degree;
			bridge.transform.Rotate (0, x, 0);
			bridge1.transform.Rotate (0, x, 0);
			player.transform.Rotate (0, x, 0);
		}
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			flag = 1;
			player = other.gameObject;
			//Destroy (gameObject);
		}
	}
}
