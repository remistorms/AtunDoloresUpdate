using UnityEngine;
using System.Collections;

public class Ganaste_Test : MonoBehaviour {

	//EN ESTE HAY QEU GUARDAR RESULTADO SI NO HAY CONEXION; Y EVNIAR SIEEMPRE ANTES DE PEDIR LISTA DE PREMIOS

	public string fecha;
	public string user;
	public string respuesta;

	void Start()
	{
		fecha = System.DateTime.Now.ToString("yyyyMMdd");
	}

	public static string HttpGet(string URI) 
	{
		System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
		System.Net.WebResponse resp = req.GetResponse();
		System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
		return sr.ReadToEnd().Trim();
	}

	public void GanaPremio(string premio)
	{
		string url = "http://www.ispinnova.com.mx/app/insert_premio.php?i=" + user + "&p=" + premio + "&f=" + fecha + "";
		respuesta = HttpGet (url);

		//
		if (respuesta == "1") 
		{
			//SE ENVIO EL PREMIO AL SERVIDOR
		} 

		else 
		{
			//NO SE ENVIO; GUARDA EN PLAYER PREFS
			PlayerPrefs.SetString("premio_pendiente", premio);
			PlayerPrefs.SetString ("fecha_pendiente", fecha);
		}
	}
}
