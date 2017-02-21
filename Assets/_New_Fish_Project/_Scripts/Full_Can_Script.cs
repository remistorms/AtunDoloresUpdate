using UnityEngine;
using System.Collections;

public class Full_Can_Script : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		iTween.MoveTo (this.gameObject, iTween.Hash ("position", Manager_Position.instance.can_target_position.position, "time", 1.5f, "delay", 0.2f));
		iTween.RotateTo (this.gameObject, iTween.Hash ("z", 1080, "time", 1f, "islocal", false, "easetype", "linear"));
		iTween.ScaleAdd (this.gameObject, iTween.Hash ("x", 5, "y", 5, "z", 5, "time", 1.5f, "easetype", "linear"));
		Destroy (this.gameObject, 1.5f);
	}
	
	public void OnDisable()
	{
		Manager_Event.EM.Fire_EVT_Got_Can ();
	}
}
