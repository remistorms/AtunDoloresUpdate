using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SeleccionDeCadena : MonoBehaviour {

	public Dropdown this_dropdown;

	public void SetCadena()
	{
		//Debug.LogError("Cadena selected: " + this_dropdown.captionText.text);
		GameSettings.instance.cadena = this_dropdown.captionText.text;
		//Opens Selection de usuario
		MainUI.instance.EnablePanel (2);
	}
}
