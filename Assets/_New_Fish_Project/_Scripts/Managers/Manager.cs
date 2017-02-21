using UnityEngine;
using System.Collections;

public abstract class Manager : MonoBehaviour {

	//They have to do it FORCE
	//public abstract void Initialize ();

	public virtual void Initialize()
	{
		Debug.Log ("This is a Manager class");
	}

}
