using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
public class purpleSkill : MonoBehaviour, IPointerDownHandler {
	public GameObject player;
	public GameObject bullet;

	private Image skillImg;
	private bool flag;
	// Use this for initialization
	private void Start() {
		flag = true;
		skillImg = GetComponent<Image> ();
	}

	void PurpleSkill()
	{
		//Camera cam = GetComponentInChildren<Camera> ();
		if (flag) {
			Instantiate(bullet, player.transform.position, player.transform.rotation);
		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (skillImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			PurpleSkill ();
		}

	}

	void Update(){
		if (Input.GetKey (KeyCode.Space)) {
			PurpleSkill ();
		}
	}
}
