using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Mission4_Player_Controller : MonoBehaviour {

	public GameObject cam;

	public float moveSpeed;
	public float rotateSpeed;
	public Image backgroundImage;
	public Material greenMaterial;
	public Image skillButton;

	private bool restart;
	private VirtualJoystick joystick;
	private Renderer rend;

	private bool bridge_rotate_flag = false;
	private int bridge_rotate_count = 0;
	public GameObject bridge_rotate_1;
	public GameObject bridge_rotate_2;
	public GameObject bridge_rotate_3;

	public GameObject coin_audio;
	void Start()
	{
		restart = false;
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
		if (bridge_rotate_flag) {
			rotate_bridge ();
			bridge_rotate_count++;
			if (bridge_rotate_count == 120) {
				bridge_rotate_flag = false;
				bridge_rotate_count = 0;
			}
		} else {
			transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
			var x = joystick.Horizontal () * Time.deltaTime * rotateSpeed;
			transform.Rotate (0, x, 0);

			transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		}


		if (transform.position.y < -10) {
			restart = true;
		}

		if (restart) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin")) {
			Destroy (other.gameObject);
		}
		else if (other.gameObject.CompareTag ("Hulu")) {
			rend.sharedMaterial = greenMaterial;
			skillButton.color = Color.green;
			Destroy (other.gameObject);
		}
		else if (other.gameObject.CompareTag ("Obstacle")) {
			restart = true;
		}
		else if (other.gameObject.CompareTag ("Rotate_point")) {
			Destroy (other.gameObject);
			bridge_rotate_flag = true;
		}
		else if (other.gameObject.CompareTag ("Coin4")) {
			AudioSource audio = coin_audio.GetComponent<AudioSource> ();
			audio.Play ();
			Destroy (other.gameObject);
		}
	}

	void rotate_bridge(){
		var x =Time.fixedDeltaTime * 20;
		transform.Rotate (0, x, 0);
		bridge_rotate_1.transform.Rotate (0, x, 0);
		bridge_rotate_2.transform.Rotate (0, x, 0);
		bridge_rotate_3.transform.Rotate (0, x, 0);
	}
}
