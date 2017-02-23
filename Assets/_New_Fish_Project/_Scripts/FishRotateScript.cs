using UnityEngine;
using System.Collections;

public class FishRotateScript : MonoBehaviour {

	 float rotate_speed = 10f;
	public Transform my_transform;
	// Use this for initialization
	void Start () 
	{
		my_transform = this.transform;
		//iTween.RotateTo (this.gameObject, iTween.Hash ("x", 360, "speed", rotate_speed, "looptype", "loop", "easetype", "linear"));
	}

	void FixedUpdate()
	{
		my_transform.RotateAroundLocal (Vector3.right, rotate_speed * Time.deltaTime);
	}
}
