using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotonPremio : MonoBehaviour {

	public string premio;
	public string difficulty;
	public Button this_button;
	public int latas_para_ganar;

	// Use this for initialization
	void Start () 
	{
		this_button = GetComponent<Button> ();
	}

	public void StartGame()
	{
		GameSettings.instance.cans_needed_to_win = latas_para_ganar;
		GameSettings.instance.selected_prize = premio;
		GameSettings.instance.fecha_juego = System.DateTime.Now.ToString ("yyyyMMdd");

		switch (difficulty) 
		{
			case "1":
			GameControl.instance.StartGameEasy ();
			break;

			case "2":
			GameControl.instance.StartGameMedium ();
			break;

			case "3":
			GameControl.instance.StartGameHard ();
			break;

			default:
			break;
		}
	}

}
