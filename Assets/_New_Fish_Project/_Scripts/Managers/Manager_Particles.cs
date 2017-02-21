using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager_Particles : MonoBehaviour {

	public static Manager_Particles instance;
	public GameObject splash_particle_prefab;

	public List<GameObject> pooled_splash, used_splash; 

	public void Initialize()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		

		for (int i = 0; i < 20; i++) 
		{
			GameObject splash_clone = Instantiate (splash_particle_prefab, transform.position, Quaternion.identity) as GameObject;
			splash_clone.transform.SetParent (this.gameObject.transform);
			pooled_splash.Add (splash_clone);
			splash_clone.SetActive (false);
		}
	}

	public void SpawnSplash(Vector3 position)
	{
		StartCoroutine (SplashRoutine (position));
	}

	IEnumerator SplashRoutine(Vector3 point)
	{
		Debug.Log ("SplashRoutine started");
		if (pooled_splash.Count > 0) 
		{
			GameObject selected_particle = pooled_splash [0];
			pooled_splash.Remove (selected_particle);
			used_splash.Add (selected_particle);

			selected_particle.transform.position = point;
			selected_particle.SetActive (true);
			selected_particle.GetComponent<ParticleSystem> ().Emit (1);
			yield return new WaitForSeconds (0.5f);

			selected_particle.transform.localPosition = Vector3.zero;
			used_splash.Remove (selected_particle);
			pooled_splash.Add (selected_particle);
			selected_particle.SetActive (false);

		}
	}
}
