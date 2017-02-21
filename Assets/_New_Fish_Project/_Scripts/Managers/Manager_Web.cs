using UnityEngine;
using System.Collections;

public class Manager_Web : MonoBehaviour {

	public static Manager_Web instance;

	public string get_premio_url = "http://www.ispinnova.com.mx/app/get_premios.php?";
	public string insert_premio_url = "http://www.ispinnova.com.mx/app/insert_premio.php?";
	//SAVE THIS IN PLAYER PREFS
	public string pending_premio_url;

	/*
	Parametros para get premio URL
	i= CADENA,f = fecha
	http://www.ispinnova.com.mx/app/get_premios.php?i=LA GUADALUPANA SUC. 1 NAJE J&f=20161118
	*/

	//////////

	/*
	Parametros para insert premio URL
	i= CADENA, p=Premio, f = fecha, n= nombre_cliente, t=numero_ticket, r=resultado GANO O PERDIO, l=numero de latas
	http://www.ispinnova.com.mx/app/insert_premio.php?i=LA GUADALUPANA SUC. 1 NAJE J&p=TABLETS&f=20161115&n=LUIS ALBERTO CAMPOS&t=12132231231434234&r=GANO&l=10
	*/

	

	public void Initialize()
	{
		instance = this;
	}
		
	public string HttpGet(string URI) 
	{
		System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
		System.Net.WebResponse resp = req.GetResponse();
		System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
		return sr.ReadToEnd().Trim();
	}

	public bool CheckInternetConection()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable) 
		{
			Debug.LogError ("No Hay CONECCION");
			Debug.Log ("Error. Check internet connection!");
			return false;
		} 
		else 
		{ 
			return true;
		}
	}


}
