using UnityEngine;
using System.Collections;

public class Fish_Script : MonoBehaviour {

	public bool spawn_splash = true;
	public float fish_value = 1;
	public GameObject shadow_projector;
	public Rigidbody fish_rigid_body;
	Fish_Audio fish_audio_ref;
	// Use this for initialization
	void Start () 
	{
		//Destroy (this.gameObject, life_span);
		shadow_projector.transform.forward = new Vector3 (0, -1, 0);
		fish_rigid_body = GetComponent<Rigidbody> ();
		fish_audio_ref = GetComponent<Fish_Audio> ();
	}
	
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Game_Area") 
		{
			
			fish_audio_ref.PlaySplash ();
			if (spawn_splash) 
			{
				Vector3 splash_pos = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
				Manager_Particles.instance.SpawnSplash (splash_pos);
			}
			//GameObject splash = Instantiate (splash_particle, splash_pos, Quaternion.Euler(new Vector3(-90,0,0))) as GameObject;
			//Destroy (splash, 0.5f);
		}

		if (other.name == "ReturnVolume") 
		{
			ReturnToPool ();
		}
	}

	public void ReturnToPool()
	{
		Fish_Spawner.instance.ReturnToPool (this.gameObject);	
	}

	void OnDisable()
	{
		//Debug.Log ("Fish has been destroyed");
		//Manager_Event.EM.Fire_EVT_Destroyed_Fish ();
	}
}
