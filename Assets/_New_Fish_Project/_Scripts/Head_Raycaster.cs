using UnityEngine;
using System.Collections;

public class Head_Raycaster : MonoBehaviour {

	public GameObject Tunafish_Can_GO;
	GameObject hit_object;
	Ray my_ray;
	RaycastHit my_hit;
	public float cam_delay = 0.5f;

	// Update is called once per frame
	void Update () 
	{
		ShootRay ();
	}

	void ShootRay()
	{
		
		my_ray = new Ray (transform.position, transform.forward);
		//Debug.DrawRay (this.transform.position, this.transform.forward, Color.green);

		//Checks to see if the player is aiming at playable area
		if (Physics.Raycast (my_ray, out my_hit, 300) && my_hit.collider.tag == "Game_Area") 
		{
			hit_object = my_hit.collider.gameObject;
			//Tunafish_Can_GO.transform.position = my_hit.point;
			Tunafish_Can_GO.transform.position = Vector3.Lerp(Tunafish_Can_GO.transform.position, my_hit.point, cam_delay * Time.deltaTime);
		} 


	}
}
