using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour {

	[SerializeField] Manager_IO manager_IO_ref;
	[SerializeField] Manager_Sound manager_Sound_ref;
	[SerializeField] Manager_Difficulty manager_Difficulty_ref;
	[SerializeField] Manager_Score manager_Score_ref;
	[SerializeField] Manager_Game manager_Game_ref;
	[SerializeField] Manager_UI manager_UI_ref;
	[SerializeField] Manager_Event manager_Event_ref;
	[SerializeField] GameSettings game_settings_ref;
	[SerializeField] Manager_Web manager_web_ref;

	void Start () 
	{
		StartCoroutine (_Boot ());	
	}

	private IEnumerator _Boot()
	{
		manager_IO_ref.Initialize ();
		manager_Sound_ref.Initialize ();
		game_settings_ref.Initialize ();
		manager_web_ref.Initialize ();
		yield return null;
		//SceneManager.LoadScene ("Mechanics", LoadSceneMode.Additive);
	}

}
