using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanPile : MonoBehaviour {

	public static CanPile instance;
	public GameObject[] cans;
	public int current_cans = 0;
	public Text can_count_label;

	public void Initialize()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		
		DisableCans ();
		Manager_Event.EM.EVT_Got_Can += AddCanToPile;
	}

	public void AddCanToPile()
	{
		if (current_cans < 10) 
		{
			cans [current_cans].SetActive (true);
			current_cans++;
			can_count_label.text = current_cans.ToString();
		}
	}

	public void DisableCans()
	{
		foreach (var item in cans) 
		{
			item.SetActive (false);
		}


	}

	void OnDisable()
	{
		Manager_Event.EM.EVT_Got_Can -= AddCanToPile;
	}
}
