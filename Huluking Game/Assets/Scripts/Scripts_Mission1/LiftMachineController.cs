using UnityEngine;
using System.Collections;

public class LiftMachineController : MonoBehaviour {

	public GameObject player;
	private float speed;
	private PlayerController playerController;
	private float speedBK;
	private bool flag1;
	private bool flag2;

	// Use this for initialization
	void Start ()
	{
		flag1 = false;
		flag2 = true;
		speed = 0.2f;
		playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flag1) {
			if (player.transform.localScale.x == 4) {
				speedBK = playerController.moveSpeed;
				playerController.moveSpeed = 0;
				Animation animation = GetComponent<Animation> ();
				animation ["LiftControllerAnimation"].speed = speed;
				animation.Play ();
				flag1 = false;
			}
		}

		if (flag2 && transform.position.y >= 15) {
			if (player.transform.localScale.x == 1) {
				playerController.moveSpeed = speedBK;
				flag2 = false;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Player")) {
			flag1 = true;
		}
	}
}
