using UnityEngine;
using System.Collections;
using System;

public class Manager_Event : Manager {

	public static Manager_Event EM;

	public Action EVT_Game_Start;
	public Action EVT_Game_Over;
	public Action EVT_Got_Can;


	// Use this for initialization
	public void Initialize () 
	{
		EM = this;
	}

	public void Fire_EVT_Game_Start()
	{
		if (EVT_Game_Start != null) 
		{
			EVT_Game_Start ();
		}
	}

	public void Fire_EVT_Game_Over()
	{
		if (EVT_Game_Over != null) 
		{
			//Debug.LogError ("Gave Over Event Has Been Fired");
			EVT_Game_Over ();	
		}
	}

	public void Fire_EVT_Got_Can()
	{
		if (EVT_Got_Can != null) 
		{
			EVT_Got_Can ();	
		}
	}

}
