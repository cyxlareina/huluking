using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public Vector3 pos;
	public float interval;
	public int num; 
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < num; i++) {
			Instantiate (enemy, new Vector3 (pos.x + i * interval, pos.y, pos.z), Quaternion.identity);
		}
		for (int i = 0; i < num; i++) {
			Instantiate (enemy, new Vector3 (pos.x + i * interval + 5, pos.y, pos.z - 2), Quaternion.Euler(0, 180, 0));
		}
	}
}
