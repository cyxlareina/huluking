using UnityEngine;
using System.Collections;

public class RedPlaneController : MonoBehaviour {
	
	public Material material;
	private PlayerController playerController;

	void Start()
	{
		GameObject player = GameObject.FindWithTag("Player");
		if (player == null) {
			Debug.Log("Can't find 'Player' tag.");
			return;
		}
		playerController = player.GetComponent<PlayerController> ();
		if (playerController == null)
		{
			Debug.Log("Can't find 'PlayerController' script.");
			return;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			other.gameObject.GetComponent<Renderer> ().sharedMaterial = material;
			bool[] skills = playerController.getSkillsArray ();
			for (int i = 0; i < skills.Length; i++) {
				if (i == 0) {
					skills [i] = true;
				} else {
					skills [i] = false;
				}
			}
		}
	}
}
