using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SeleccionDePlaza : MonoBehaviour {

	public Dropdown this_drop_down;

	public void OpenSelecCadena()
	{
		//Debug.LogError ("Open Select Cadena Panel with option " + this_drop_down.value.ToString ());
		Debug.LogError("Selected Value of Cadena is " + this_drop_down.value.ToString() + " " + this_drop_down.captionText);
		switch (this_drop_down.value) 

	
		{

		case 1:
			GameSettings.instance.plaza = "Guadalajara";
			MainUI.instance.EnableCadenaPanel (this_drop_down.value );
			break;

			case 2:
			GameSettings.instance.plaza = "Monterrey";
			MainUI.instance.EnableCadenaPanel (this_drop_down.value );
			break;

			case 3:
			GameSettings.instance.plaza = "Puebla";
			MainUI.instance.EnableCadenaPanel (this_drop_down.value );
			break;

			case 4:
			GameSettings.instance.plaza = "Queretaro";
			MainUI.instance.EnableCadenaPanel (this_drop_down.value );
			break;

			case 5:
			GameSettings.instance.plaza = "SLP";
			MainUI.instance.EnableCadenaPanel (this_drop_down.value);
			break;

			case 6:
			GameSettings.instance.plaza = "Leon";
			MainUI.instance.EnableCadenaPanel (this_drop_down.value);
			break;

			case 7:
			GameSettings.instance.plaza = "Valle de Mexico";
			MainUI.instance.EnableCadenaPanel (this_drop_down.value);
			break;

			default:
			Debug.Log ("Error selecting cadena");
			break;
		}
	}
		
}
