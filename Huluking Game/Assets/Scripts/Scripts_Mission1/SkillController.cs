using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SkillController : MonoBehaviour,IPointerDownHandler {

	public GameObject player;
	public PlayerController playController;
	public Camera cam;
	private Image skillImg;
	private bool flag;

	// Use this for initialization
	private void Start() {
		flag = false;
		skillImg = GetComponent<Image> ();
		if (player != null) {
			playController = player.GetComponent<PlayerController> ();
		}
	}

	void RedSkill()
	{
		//Camera cam = GetComponentInChildren<Camera> ();
		Vector3 position = cam.transform.position;
		if (flag) {
			player.transform.localScale = new Vector3 (1, 1, 1);
			flag = false;
		} else {
			player.transform.localScale = new Vector3 (4, 4, 4);
			flag = true;
		}
		cam.transform.position = position;
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (skillImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			if (playController != null && playController.isSkilled ()) {
				RedSkill ();
			}
		}

	}
}
