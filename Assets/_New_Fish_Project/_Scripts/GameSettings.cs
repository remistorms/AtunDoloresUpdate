using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSettings : MonoBehaviour {

	public static GameSettings instance;

	//DATOS PARA CONCATENAR LOS STREINGS URL
	public string client_name;
	public string ticket_number;
	public string selected_prize;
	public string fecha_juego;
	public string resultado_de_juego;
	public string latas_conseguidas;
	public string plaza;
	public string cadena;

	// Strings
	public string full_string_to_send;
	public string super_string_lista;
	public string[] premio_dificultad;
	public  List<string> premios;
	public  List<string> difficultades;

	public string premio_por_enviar;
	//
	public int cans_needed_to_win;

	public void Initialize()
	{
		instance = this;
		premio_por_enviar = PlayerPrefs.GetString ("url_pendiente");
	}

	public void FillAllStrings()
	{
		if (PlayerPrefs.GetString ("url_pendiente") == "") 
		{
			full_string_to_send = "http://www.ispinnova.com.mx/app/get_premios.php?" + "i=" + cadena + "&f=" + System.DateTime.Now.ToString ("yyyyMMdd") + ""; 

			super_string_lista = Manager_Web.instance.HttpGet (full_string_to_send);
			premio_dificultad = super_string_lista.Split ('|');

			for (int i = 0; i < premio_dificultad.Length - 1; i++) {
				string[] temp_string = premio_dificultad [i].Split (',');
				premios.Insert (i, temp_string [0]);
				difficultades.Insert (i, temp_string [1]);
			}
		} 

		else 
		{
			SendPremioPendiente ();
		}


	}

	public void SendPremio()
	{
		string insert_premio_string = "http://www.ispinnova.com.mx/app/insert_premio.php?i=" + cadena + "&f=" + fecha_juego + "&p=" + selected_prize + "&n=" + client_name.Replace("/","").Replace("#","").Replace("'","").Replace("@","").Replace("Ñ","N").Replace("ñ","n") + "&t=" + ticket_number.Replace("/","").Replace("#","").Replace("'","").Replace("@","").Replace("Ñ","N").Replace("ñ","n") + "&r=" + resultado_de_juego + "&l=" + latas_conseguidas + ""; 

		if (Manager_Web.instance.CheckInternetConection ()) 
		{
			//Si hay internet

			string respuesta_peticion_insert_premio = Manager_Web.instance.HttpGet (insert_premio_string);
			//string respuesta_peticion_insert_premio = "1";

			if (respuesta_peticion_insert_premio == "1") 
			{
				//Clear Player Prefs
				PlayerPrefs.SetString("url_pendiente", "");
				// MOSTRAR PANTALLA DE POST GAME GANO O PIERDE
				MainUI.instance.ShowPostGameScreen();
			} 

			else 
			{
				// Almacena en player prefs el insert premio string
				PlayerPrefs.SetString("url_pendiente", insert_premio_string);
				//MOSTRAR PANTALLA DE POST GAME GANE O PIERDA
				MainUI.instance.ShowPostGameScreen();
			}
		} 

		else 
		{
			// Almacena en player prefs el insert premio string
			PlayerPrefs.SetString("url_pendiente", insert_premio_string);
			//MOSTRAR PANTALLA DE POST GAME GANE O PIERDA
			MainUI.instance.ShowPostGameScreen();
		}
	}

	public void SendPremioPendiente()
	{
		string insert_premio_string = PlayerPrefs.GetString ("url_pendiente");

		if (Manager_Web.instance.CheckInternetConection ()) {
			//Si hay internet

			string respuesta_peticion_insert_premio = Manager_Web.instance.HttpGet (insert_premio_string);
			//string respuesta_peticion_insert_premio = "1";

			if (respuesta_peticion_insert_premio == "1") {
				//Clear Player Prefs
				PlayerPrefs.SetString ("url_pendiente", "");

			} 

			else 
			{
				//MOSTRAR PANTALLA DE ERROR DE CONEXION
				MainUI.instance.ShowErrorScreen();
			}

		} 
		else 
		{
			//MOSTRAR PANTALLA DE ERROR DE CONEXION
			MainUI.instance.ShowErrorScreen();
		}

	}

	public void CheckForPremio()
	{
		latas_conseguidas = CanPile.instance.current_cans.ToString();
		if ( int.Parse(latas_conseguidas) >= cans_needed_to_win) 
		{
			resultado_de_juego = "GANO";
		} 

		else 
		{
			resultado_de_juego = "PERDIO";
		}
	
		if (premio_por_enviar == "") 
		{
			//Uncomment this after testing
			SendPremio ();	

		} 
		else 
		{
			//Uncomment this after testing
			SendPremioPendiente ();
		}
	}
}
