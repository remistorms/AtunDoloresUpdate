using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {

	public GameChecker game_checker_ref;
	public GameControl game_control_ref;
	public Manager_Particles manager_particle_ref;
	public Manager_Event manager_event_ref;
	public CanPile can_pile_ref;
	public Manager_Position manager_position_ref;
	public Fish_Spawner fish_spawner_ref;
	public MainUI main_ui_ref;
	public Manager_Sound manager_sound_ref;

	// Use this for initialization
	void Awake () 
	{
		game_control_ref.Initialize ();
		game_checker_ref.Initialize ();
		manager_event_ref.Initialize ();
		manager_particle_ref.Initialize ();
		can_pile_ref.Initialize ();
		fish_spawner_ref.Initialize ();
		manager_position_ref.Initialize ();
		main_ui_ref.Initialize ();
		manager_sound_ref.Initialize ();
	}

}
