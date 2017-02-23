using UnityEngine;
using System.Collections;

public class Trash_Script : MonoBehaviour {

	public GameObject[] trash_meshes;
	// Use this for initialization
	void Start () 
	{
		this.gameObject.tag = "Trash";

		foreach (var item in trash_meshes) 
		{
			item.SetActive (false);
		}

		trash_meshes [Random.Range (0, 3)].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
