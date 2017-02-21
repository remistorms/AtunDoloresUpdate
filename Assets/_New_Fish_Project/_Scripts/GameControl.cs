using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Gvr.Internal;
using UnityEngine.SceneManagement;

public class GameControl : Manager {

	float time_to_wait_for_visor = 5f;
	public static GameControl instance;
	public bool vr_enabled = false;
	public float time_left = 90;
	public bool game_over = true;
	public GameObject cardboard_Object;
	public GvrViewer vr_viewer_instance;

	public override void Initialize ()
	{
		instance = this;
	}

	void Start()
	{
		//Starts the game in 2D mode for actions, options and more
		vr_viewer_instance.VRModeEnabled = false;
		cardboard_Object.SetActive (false);
		Manager_Sound.instance.PlayLobbyMusic ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			vr_viewer_instance.VRModeEnabled = true;
			Manager_Event.EM.Fire_EVT_Game_Start ();
		}
	}

	void StartGame()
	{
		cardboard_Object.SetActive (true);
		//vr_viewer_instance.VRModeEnabled = true;
		Manager_Event.EM.Fire_EVT_Game_Start ();
		MainUI.instance.GameStartTimer ();
	}

	public void StartGameEasy()
	{
		StartCoroutine (StartEasyRoutine ());
	}

	public void StartGameMedium()
	{
		StartCoroutine (StartMediumRoutine ());
	}
		

	public void StartGameHard()
	{
		StartCoroutine (StartHardRoutine ());
	}

	IEnumerator StartEasyRoutine()
	{
		
		MainUI.instance.DisableAllPanels ();
		MainUI.instance.EnablePanel (4);
		MainUI.instance.HeadsetPanelRoutine (time_to_wait_for_visor);
		yield return new WaitForSeconds (time_to_wait_for_visor);
		MainUI.instance.DisableAllPanels ();

		Manager_Sound.instance.PlayMainMuscic ();
		cardboard_Object.SetActive (true);
		//vr_viewer_instance.VRModeEnabled = true;
		Manager_Event.EM.Fire_EVT_Game_Start ();
		MainUI.instance.GameStartTimer ();
		Fish_Spawner.instance.StartEasyMode ();
	}

	IEnumerator StartMediumRoutine()
	{
		
		MainUI.instance.DisableAllPanels ();
		MainUI.instance.EnablePanel (4);
		MainUI.instance.HeadsetPanelRoutine (time_to_wait_for_visor);
		yield return new WaitForSeconds (time_to_wait_for_visor);
		MainUI.instance.DisableAllPanels ();

		Manager_Sound.instance.PlayMainMuscic ();
		cardboard_Object.SetActive (true);
		//vr_viewer_instance.VRModeEnabled = true;
		Manager_Event.EM.Fire_EVT_Game_Start ();
		MainUI.instance.GameStartTimer ();
		Fish_Spawner.instance.StartMediumMode ();
	}

	IEnumerator StartHardRoutine()
	{
		MainUI.instance.DisableAllPanels ();
		MainUI.instance.EnablePanel (4);
		MainUI.instance.HeadsetPanelRoutine (time_to_wait_for_visor);
		yield return new WaitForSeconds (time_to_wait_for_visor);
		MainUI.instance.DisableAllPanels ();

		Manager_Sound.instance.PlayMainMuscic ();
		cardboard_Object.SetActive (true);
		//vr_viewer_instance.VRModeEnabled = true;
		Manager_Event.EM.Fire_EVT_Game_Start ();
		MainUI.instance.GameStartTimer ();
		Fish_Spawner.instance.StartHardMode ();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}
}
