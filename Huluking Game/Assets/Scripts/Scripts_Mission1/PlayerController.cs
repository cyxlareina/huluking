using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

	public GameObject cam;

	public float moveSpeed;
	public float rotateSpeed;
	public Image backgroundImage;
	public Material redMaterial;
	public Image skillButton;

	private bool restart;
	private bool skillFlag;
	private VirtualJoystick joystick;
	private Renderer rend;
	private float jumpPower = 400;
	private Rigidbody rb;
	private bool jumpFlag;
	private bool flag = false;
	private AudioSource audio;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		restart = false;
		skillFlag = false;
		jumpFlag = false;
		joystick = backgroundImage.GetComponent<VirtualJoystick> ();
		audio = GetComponent<AudioSource> ();
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

		if (jumpFlag && transform.localScale.x == 1) {
			rb.AddForce (Vector3.up * jumpPower);
			if (transform.position.y >= 1) {
				jumpFlag = false;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) && skillFlag) {
			RedSkill ();
		}

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
		} else if (other.gameObject.CompareTag ("Hulu")) {
			rend.sharedMaterial = redMaterial;
			skillButton.color = Color.red;
			activateSkill ();
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Bullet")) {
			/* ++++++ */
			restart = true;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Jump_Plane")) {
			if (transform.localScale.x == 4) {
				Destroy (collision.gameObject);
			} else {
				jumpFlag = true;
			}
		} else if (collision.gameObject.CompareTag ("Cub_Obstacle")) {
			if (transform.localScale.x == 1) {
				/* ++++++ */
				restart = true;
			}
		} else {
			// audio.Play ();
		}
	}

	public bool isSkilled()
	{
		return skillFlag;
	}

	public void deactivateSkill()
	{
		skillFlag = false;
	}

	public void activateSkill()
	{
		skillFlag = true;
	}

	void RedSkill()
	{
		//Camera cam = GetComponentInChildren<Camera> ();
		Vector3 position = cam.transform.position;
		if (flag) {
			transform.localScale = new Vector3 (1, 1, 1);
			flag = false;
		} else {
			transform.localScale = new Vector3 (4, 4, 4);
			flag = true;
		}
		cam.transform.position = position;
	}
}