using UnityEngine;
using System.Collections;

public class REF : MonoBehaviour {

	[SerializeField] Manager_IO manager_IO_ref;
	[SerializeField] Manager_Sound manager_Sound_ref;
	[SerializeField] Manager_Difficulty manager_Difficulty_ref;
	[SerializeField] Manager_Score manager_Score_ref;
	[SerializeField] Manager_Game manager_Game_ref;
	[SerializeField] Manager_Event manager_Event_ref;
	[SerializeField] Manager_UI manager_UI_ref;
	[SerializeField] GameSettings game_settings_ref;

	public Manager_IO M_IO { get {return manager_IO_ref; } }
	public Manager_Sound M_Sound { get { return manager_Sound_ref; } }
	public Manager_Difficulty M_Difficulty { get { return manager_Difficulty_ref; } }
	public Manager_Score M_Score { get { return manager_Score_ref; } }
	public Manager_Game M_Game { get { return manager_Game_ref; } }
	public Manager_Event M_Event { get { return manager_Event_ref; } }
	public Manager_UI M_UI { get { return manager_UI_ref; } }
	public GameSettings G_Settings {get { return game_settings_ref;}}

	public static REF Instance;

	void Awake()
	{
		Instance = this;
	}

}
