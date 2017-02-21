using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class DropDownTester : MonoBehaviour {

	public Dropdown zone_dropdown;

	public void ZoneSelected()
	{
		Debug.Log ("selected option" +zone_dropdown.value.ToString () + " from the dropdown menu");

	}


}
