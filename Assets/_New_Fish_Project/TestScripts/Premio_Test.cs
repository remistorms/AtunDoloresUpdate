using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Premio_Test : MonoBehaviour {

	string url = "";
	public string fecha;
	public string premios_superlist;
	public string[] premio;
	//Cambia por diccionario
	public string[] premio_dificultad;

	public string user;


	//CHECAR SI HAY PREMIO PENDIENDE POR ENVIAR EM PLAYER PREFS

	void Start()
	{
		fecha = System.DateTime.Now.ToString("yyyyMMdd");
	}

	public void PedirListaPremios()
	{
		//CHECAR QUE NO HAY PREMIO PENDIENTE
		if (PlayerPrefs.GetString ("premio_pendiente") == "") {
			
			url = "http://www.ispinnova.com.mx/app/get_premios.php?i=" + user + "&f=" + fecha + "";
			premios_superlist = HttpGet (url);
			premio = premios_superlist.Split ('|');
			SplitAllPremios ();

		} 
		else 
		{
			//ENviar peticion webservice inster premio, USANDO PLAYER PREFS
			/*
			if (respuesta == "1") 
			{
				//LIMPIAS PLAYER PREFS

				//pides premios
			} 

			else 
			{
				Debug.Log ("INTENTE DE NUEVO; PROBLEMAS DE CONEXION...");
				return;
			}*/
		}



	}

	public static string HttpGet(string URI) 
	{
		System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
		System.Net.WebResponse resp = req.GetResponse();
		System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
		return sr.ReadToEnd().Trim();
	}

	void SplitAllPremios()
	{
		for (int i = 0; i < premio.Length - 1; i++) 
		{
			premio_dificultad = premio [i].Split(',');

			//Desmadre de Botones

		}

	}
}
