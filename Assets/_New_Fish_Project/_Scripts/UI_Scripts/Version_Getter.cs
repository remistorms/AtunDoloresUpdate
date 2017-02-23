using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Version_Getter : MonoBehaviour {

	public Text version_text;
	// Use this for initialization
	void Start () 
	{
		version_text = GetComponent<Text> ();
		version_text.text = Application.version.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
