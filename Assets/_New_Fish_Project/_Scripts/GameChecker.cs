using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameChecker : MonoBehaviour {

	public static GameChecker instance;

	public string imei;
	public Text imei_label;


	// Use this for initialization
	public void Initialize () 
	{
		instance = this;
	}



}
