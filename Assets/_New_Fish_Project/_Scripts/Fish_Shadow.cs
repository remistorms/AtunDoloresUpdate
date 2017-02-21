using UnityEngine;
using System.Collections;

public class Fish_Shadow : MonoBehaviour {

	public Ray my_ray;
	public RaycastHit my_hit;
	public MeshRenderer shadow_plane;
	
	// Update is called once per frame
	void Update () 
	{
		my_ray = new Ray (this.transform.position, -Vector3.up);

		if (Physics.Raycast (my_ray, out my_hit, 50) && my_hit.collider.tag == "Game_Area" && this.transform.position.y > 0.1f) 
		{
			shadow_plane.transform.position = my_hit.point;
		} 

		else 
		{
			shadow_plane.transform.position = new Vector3 (0, -500, 0);
		}
	}
}
