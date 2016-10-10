using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {

	public Texture2D HealthBg;  
	public Texture2D Heathforce;  

	public Vector2 offset = new Vector2(13,15);  


	void Setup()  
	{  
	}  
		

	// Use this for initialization  
	void Start () {  
		Setup();  
	}  

	// Update is called once per frame  
	void Update () {  

	}  

	void OnGUI()  
	{  
		Vector3 wordPos = new Vector3 (transform.position.x , transform.position.y + 4,transform.position.z);
		Vector2 pos =Camera.main.WorldToScreenPoint (wordPos);
		Vector2 position = new Vector2 (pos.x, Screen.height - pos.y);

		Rect rectbg=new Rect(position.x-50,position.y - 10 ,position.x+50,position.y + 10);  

		GUI.DrawTexture(rectbg, HealthBg);  

		Rect rectfc = new Rect(0, 0, 120, 64);  
		GUI.DrawTexture(rectfc, Heathforce);  
	}
}
