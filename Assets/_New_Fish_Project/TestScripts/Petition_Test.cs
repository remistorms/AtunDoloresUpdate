using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Petition_Test : MonoBehaviour {

	public string recurring_user;
	public string url = "http://www.ispinnova.com.mx/app/login.php?";
	public string user_name, user_password;
	public InputField user_input_field, password_input_field;
	public string result;


	public static string HttpGet(string URI) 
	{
		System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
		System.Net.WebResponse resp = req.GetResponse();
		System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
		return sr.ReadToEnd().Trim();
	}



	public void Login()
	{

		//CAMBIAR COMO EL OTRO URL

		if (user_input_field.text != "" && password_input_field.text != "") 
		{
			user_name = user_input_field.text;
			user_password = password_input_field.text;
			url = url + "p=" + user_password + "&u=" + user_name;

			result = HttpGet (url);

			if (result == "1") 
			{
				//Almacena User Name para siempre
				recurring_user = user_name;
				//Manda A la siguiente pantalla
			} 
			else 
			{
				Debug.LogError ("Usuario o Password incorrecto");
				url = "http://www.ispinnova.com.mx/app/login.php?";
			}
		}

	}
}
