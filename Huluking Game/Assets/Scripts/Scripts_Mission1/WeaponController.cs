using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject bullet;
	public float interval;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		while (true) {
			Instantiate (bullet, transform.position, transform.rotation);
			yield return new WaitForSeconds (interval);
		}
	}
}
