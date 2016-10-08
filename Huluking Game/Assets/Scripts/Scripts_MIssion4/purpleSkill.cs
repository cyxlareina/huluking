using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
public class purpleSkill : MonoBehaviour, IPointerDownHandler {
	public GameObject player;
	public GameObject bullet;
	public GameObject bullet_rotation_x;

	private Image skillImg;
	private bool flag;
	// Use this for initialization
	private void Start() {
		flag = false;
		skillImg = GetComponent<Image> ();
	}

	void PurpleSkill()
	{
		Debug.Log ("bullet x: "+bullet_rotation_x.transform.rotation);
		float x = bullet_rotation_x.transform.rotation.x;
		float y = player.transform.rotation.y;
		float z = player.transform.rotation.z;
		float w = player.transform.rotation.w;
		Quaternion rotation = new Quaternion (x, y, z, w);
		//Camera cam = GetComponentInChildren<Camera> ();
		if (flag) {
			Instantiate(bullet, player.transform.position, rotation);
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
		if (skillImg.color == Color.green) {
			flag = true;
		}
	}
}
