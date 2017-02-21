using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DatosDeCliente : MonoBehaviour {

	public InputField nombre_cliente;
	public InputField numero_de_ticket;


	// Use this for initialization
	void Start () 
	{
		nombre_cliente.text = "";
		numero_de_ticket.text = "";
	}
	
	public void GetDatosCliente()
	{
		if (Manager_Web.instance.CheckInternetConection () == true) 
		{
			if (nombre_cliente.text != "" && numero_de_ticket.text != "") {
				GameSettings.instance.client_name = nombre_cliente.text;
				GameSettings.instance.ticket_number = numero_de_ticket.text;
				GameSettings.instance.FillAllStrings ();
				MainUI.instance.EnablePanel (3);
			} else 
			
			{
				Debug.LogError ("Necesita usuario y ticket");
			}
		} 
		else 
		{
			Debug.LogError ("NO HAY INTERNE !!!");
			MainUI.instance.ShowErrorScreen ();
		}
	}
}
