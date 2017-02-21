using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {

	public static MainUI instance;

	public GameObject[] panels;
	public GameObject[] cadenas_panels;
	public Image timer_circle;
	public Text timer_numbers;
	public float real_time = 90;
	bool has_started = false;
	public CanvasGroup headset_panel;
	public Image[] counter_images;
	public GameObject error_message_panel;
	public GameObject loading_panel;
	public Text[] total_cans_text_label;
	bool game_has_stopped;

	[SerializeField] InfoScript[] info_scripts;

	public void Initialize()
	{
		instance = this;
	}
	void Start()
	{
		//Manager_Event.EM.EVT_Game_Start += GameStartTimer;
		//Manager_Event.EM.EVT_Game_Over += ShowPostGameScreen;
		DisableAllPanels();
		EnablePanel (0);
		game_has_stopped = false;
	}

	void Update()
	{
		if (has_started) 
		{
			real_time -= Time.deltaTime;

			if (real_time < 30 && real_time > 29) 
			{
				Manager_Sound.instance.SetNewPitch (1.15f);
			}
			if (real_time < 0 && game_has_stopped == false) 
			{
				real_time = 0;	
				Manager_Event.EM.Fire_EVT_Game_Over ();
				game_has_stopped = true;
				//GameSettings.instance.latas_conseguidas = 
				GameSettings.instance.CheckForPremio ();
				timer_numbers.text = "00";
			}

			timer_numbers.text = Mathf.RoundToInt (real_time).ToString ();
		}

	}

	public void GameStartTimer()
	{
		StartTimer ();
		has_started = true;
		DisableAllPanels ();
	}

	void StartTimer()
	{
		iTween.ValueTo (this.gameObject, iTween.Hash ("from", 1, "to", 0, "time", 90, "easetype", "linear", "onupdate", "UpdateValue", "onupdatetarget", this.gameObject));
	}

	public void UpdateValue(float new_value)
	{
		timer_circle.fillAmount = new_value;
	}

	void OnDisable()
	{
		//Manager_Event.EM.EVT_Game_Start -= GameStartTimer;
		//Manager_Event.EM.EVT_Game_Over -= ShowPostGameScreen;
	}

	public void DisableAllPanels()
	{
		foreach (var item in panels) 
		{
			item.SetActive (false);
		}

		foreach (var item in cadenas_panels) {
			item.SetActive (false);
		}
		error_message_panel.SetActive (false);
		loading_panel.SetActive (false);
	}

	public void EnablePanel(int panel_id)
	{
		DisableAllPanels ();
		panels [panel_id].SetActive (true);
	}

	public void HeadsetPanelRoutine(float time)
	{
		StartCoroutine (CountdownForHeadsetPanel (time));
	}

	IEnumerator CountdownForHeadsetPanel(float time_left)
	{
		iTween.ValueTo (this.gameObject, iTween.Hash ("from", 1, "to", 0, "time", time_left, "onupdate", "TweenValue", "onupdatetarget", this.gameObject));
		yield return new WaitForSeconds(time_left - 1);
		iTween.ValueTo (this.gameObject, iTween.Hash ("from", 1, "to", 0, "time", 1, "onupdate", "TweenAlpha", "onupdatetarget", this.gameObject));

	}

	public void TweenValue(float new_fill_amount)
	{
		foreach (var item in counter_images) {
			item.fillAmount = new_fill_amount;
		}
	}

	public void TweenAlpha(float new_alpha)
	{
		headset_panel.alpha = new_alpha;
	}

	public void ShowErrorScreen()
	{
		DisableAllPanels ();
		error_message_panel.SetActive (true);
	}

	public void ShowLoadingPanel()
	{
		DisableAllPanels ();
		loading_panel.SetActive (true);
	}

	//SELECCION DE CADENA
	public void EnableCadenaPanel(int cadena_panel_id)
	{
		DisableAllPanels ();
		cadenas_panels [cadena_panel_id].SetActive (true);
	}

	public void ShowPostGameScreen()
	{
		//This part was added to avoid possible fraud during post game screen
		string info = GameSettings.instance.client_name + ", " +
		              GameSettings.instance.ticket_number + ", " +
		              GameSettings.instance.latas_conseguidas + ", " +
					  GameSettings.instance.selected_prize + ", " +
		              System.DateTime.Now.ToString ();

		foreach (var item in info_scripts) 
		{
			item.GetComponent<InfoScript> ().ShowInfo (info);	
		}
		// -> This is the end of the added block to avoid chanchuyo

	
		StartCoroutine (PostGameCoroutine ());
	}

	IEnumerator PostGameCoroutine()
	{
		//SETS THE NUMBER OF CANS IN THE END
		foreach (var item in total_cans_text_label) 
		{
			item.text = CanPile.instance.current_cans.ToString ();	
		}

		EnablePanel (5);
		yield return new WaitForSeconds (5);
		DisableAllPanels ();
		GameControl.instance.vr_viewer_instance.VRModeEnabled = false;



		//CONGISUIO LAS LATAS NECESARIAS O MAS
		if (CanPile.instance.current_cans >= GameSettings.instance.cans_needed_to_win) 
		{
			EnablePanel (6);
			GameSettings.instance.resultado_de_juego = "GANO";
			GameSettings.instance.latas_conseguidas = CanPile.instance.current_cans.ToString ();
		}

		//NO LOGRO CONSEGUIR LAS LATAS REQUERIDAS
		if (CanPile.instance.current_cans < GameSettings.instance.cans_needed_to_win) 
		{
			EnablePanel (7);
			GameSettings.instance.resultado_de_juego = "Perdio";
			GameSettings.instance.latas_conseguidas = CanPile.instance.current_cans.ToString ();
		}
			
	}
		
}
