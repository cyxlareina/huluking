using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	private bool[] skills = new bool[7];
	private bool[] skillsStat = new bool[7];
	public Image backgroundImage;
	private VirtualJoystick joystick;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		joystick = backgroundImage.GetComponent<VirtualJoystick> ();
		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
		// var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		var x = joystick.Horizontal() * Time.deltaTime * rotateSpeed;
		transform.Rotate(0, x, 0);
		// transform.Translate(0, 0, z);

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
		/*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * moveSpeed);

		if (Input.GetKeyUp (KeyCode.Space)) {
			for (int i = 0; i < skills.Length; i++) {
				if (skills [i]) {
					StartSkill (i);
					break;
				}
			}
		}
*/
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Obstacle"))
		{
			other.gameObject.SetActive (false);
		}
	}

	/*
	void StartSkill(int index)
	{
		switch (index) {
		case 0:
			RedSkill ();
			break;
		case 1:
			// orange skill
			break;
		case 2:
			// yellow skill
			break;
		case 3:
			// green skill
			break;
		case 4:
			// cyan skill
			break;
		case 5:
			// blue skill
			break;
		case 6:
			// purple skill
			break;
		}
	}

	void RedSkill()
	{
		Camera cam = GetComponentInChildren<Camera> ();
		Vector3 position = cam.transform.position;
		if (skillsStat [0] == true) {
			transform.localScale = new Vector3 (1, 1, 1);
			skillsStat [0] = false;
		} else {
			transform.localScale = new Vector3 (4, 4, 4);
			skillsStat [0] = true;
		}
		cam.transform.position = position;
	}
	*/

	public bool[] getSkillsArray()
	{
		return this.skills;
	}
}