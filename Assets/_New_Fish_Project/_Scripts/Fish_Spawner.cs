using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fish_Spawner : MonoBehaviour {

	public static Fish_Spawner instance;
	//Max distances to spawn fish from center of this Game Object
	float max_coverage_x =30, max_coverage_z = 30;
	float min_force = 20, max_force = 30;
	public GameObject fish_prefab;
	//public GameObject[] target_points;

	//POOL VARIABLES
	public int max_pooled_fish = 20;
	public Transform pool_parent;
	public List<GameObject> pooled_fish, used_fish;

	Vector3 fish_direction;

	//Difficulty Variation
	public float direction_variation = 1.0f;
	public float spawn_rate = 0.25f;

	public void Initialize()
	{
		instance = this;
	}
	void Awake()
	{
		//Subscribe from the event Destroyed Fish
		Physics.gravity = new Vector3 (0, -20, 0);
	}
	// Use this for initialization
	void Start () 
	{
		
		//InvokeRepeating ("SpawnFish", 1, 0.25f);
		//Manager_Event.EM.EVT_Game_Start += StartEasyMode;
		Manager_Event.EM.EVT_Game_Over += StopSpawning;
		PoolFish (max_pooled_fish);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S)) 
		{
			SpawnFish ();
		}
	}

	public void StartEasyMode()
	{
		spawn_rate = 0.5f;
		direction_variation = 1f;
		min_force = 25;
		max_force = 30;
		max_coverage_x = max_coverage_z = 30;
		InvokeRepeating ("SpawnFish", 1, spawn_rate);
	}

	public void StartMediumMode()
	{
		spawn_rate = 1.0f;
		direction_variation = 4f;
		min_force = 25;
		max_force = 40;
		max_coverage_x = max_coverage_z = 35;
		InvokeRepeating ("SpawnFish", 1.5f, spawn_rate);
	}

	public void StartHardMode()
	{
		spawn_rate = 1.6f;
		direction_variation = 20f;
		min_force = 25;
		max_force = 45;
		max_coverage_x = max_coverage_z = 20;
		InvokeRepeating ("SpawnFish", 1.5f, spawn_rate);
	}

	public void SpawnFish()
	{
		if (pooled_fish.Count > 0) 
		{
			GameObject selected_fish = pooled_fish [0];
			pooled_fish.Remove (selected_fish);
			used_fish.Add (selected_fish);
			ShootFish (selected_fish);
		} 
		else 
		{
			Debug.LogError ("Sorry, there are no pooled fish, wait for them to come back :) ");
		}

	}

	public void ShootFish(GameObject fish)
	{
		Vector3 random_point = new Vector3 (transform.position.x + Random.Range (-max_coverage_x, max_coverage_x), transform.position.y, transform.position.z + Random.Range (-max_coverage_z, max_coverage_z));
		float fish_force = Random.Range (min_force, max_force);
		Vector3 target_point = new Vector3(fish.transform.position.x + (Random.Range(- direction_variation, direction_variation)), 
			fish.transform.position.y + 20,
			fish.transform.position.z + (Random.Range(-direction_variation, direction_variation)));
		fish_direction = target_point - fish.transform.position;
		fish_direction = fish_direction.normalized;


		fish.transform.position = random_point;
		fish.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
		fish.GetComponent<Rigidbody> ().isKinematic = false;
		fish.GetComponent<Rigidbody> ().AddForce (fish_direction * fish_force, ForceMode.Impulse);
	}
	/*
	public void SpawnFish()
	{
		//Grab a fish from the pool
		//Place fish on a random point from the spawner
		//Add A force

			Vector3 random_point = new Vector3 (transform.position.x + Random.Range (-max_coverage_x, max_coverage_x), transform.position.y, transform.position.z + Random.Range (-max_coverage_z, max_coverage_z));
			float fish_force = Random.Range (min_force, max_force);

			GameObject spawned_fish = Instantiate (fish_prefab, random_point, Quaternion.identity) as GameObject;
			Vector3 target_point = new Vector3(spawned_fish.transform.position.x + (Random.Range(- direction_variation, direction_variation)), 
				spawned_fish.transform.position.y + 20,
				spawned_fish.transform.position.z + (Random.Range(-direction_variation, direction_variation)));
			fish_direction = target_point - spawned_fish.transform.position;
			fish_direction = fish_direction.normalized;
			//spawned_fish.transform.LookAt (fish_direction);
			spawned_fish.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
			spawned_fish.GetComponent<Rigidbody> ().AddForce (fish_direction * fish_force, ForceMode.Impulse);
			
	}*/

	public void StopSpawning()
	{
		CancelInvoke ("SpawnFish");

		foreach (var item in used_fish) 
		{
			Destroy (item);	
		}

		foreach (var item in pooled_fish) 
		{
			Destroy (item);	
		}
	}

	void OnDisable()
	{
		//Unsubscribe from the event Destroyed Fish
		//Manager_Event.EM.EVT_Game_Start -= StartEasyMode;
		Manager_Event.EM.EVT_Game_Over -= StopSpawning;
	}

	public void PoolFish(int total_fish)
	{
		for (int i = 0; i < total_fish; i++) 
		{
			GameObject spawned_fish = Instantiate (fish_prefab, pool_parent.transform.position, Quaternion.identity) as GameObject;
			spawned_fish.transform.SetParent (pool_parent);
			pooled_fish.Add (spawned_fish);
			spawned_fish.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}

	public void ReturnToPool(GameObject returning_fish)
	{
		Debug.Log ("Fish returned home safe, no harm was done...");
		used_fish.Remove (returning_fish);
		pooled_fish.Add (returning_fish);
		returning_fish.GetComponent<Rigidbody> ().isKinematic = true;
		returning_fish.transform.localPosition = Vector3.zero;
	}
}
