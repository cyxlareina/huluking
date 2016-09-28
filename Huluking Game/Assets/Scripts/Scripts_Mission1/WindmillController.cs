using UnityEngine;
using System.Collections;

public class WindmillController : MonoBehaviour {

	public float rotateSpeed;
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (Time.deltaTime * rotateSpeed, 0, 0);
	}
}
