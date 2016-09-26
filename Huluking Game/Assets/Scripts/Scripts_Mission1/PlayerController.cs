using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public Image backgroundImage;
	public Material redMaterial;
	public Image skillButton;

	private bool restart = false;
	private bool skillFlag = false;
	private VirtualJoystick joystick;
	private Renderer rend;

	void Start()
	{
		restart = false;
		skillFlag = false;
		joystick = backgroundImage.GetComponent<VirtualJoystick> ();
		if (joystick == null) {
			Debug.Log ("joystick is null");
			return;
		}
		if (skillButton == null) {
			Debug.Log ("skillButton is null");
			return;
		}
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}

	void Update()
	{

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
		var x = joystick.Horizontal() * Time.deltaTime * rotateSpeed;
		transform.Rotate(0, x, 0);
		// var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
		// var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		// transform.Translate(0, 0, z);

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

		if (transform.position.y < -10) {
			restart = true;
		}

		if (restart) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		/*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * moveSpeed);
		*/
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin")) {
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Cap_Obstacle")) {
			// collide effect
			/* ++++++ */
			restart = true;
		} else if (other.gameObject.CompareTag ("Red_Plane")) {
			rend.sharedMaterial = redMaterial;
			skillButton.color = Color.red;
			skillFlag = true;
		}
	}

	public bool isSkilled()
	{
		return skillFlag;
	}
}