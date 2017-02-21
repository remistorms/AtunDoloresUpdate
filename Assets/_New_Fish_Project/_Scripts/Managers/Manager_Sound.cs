using UnityEngine;
using System.Collections;

public class Manager_Sound : Manager {

	public static Manager_Sound instance;

	public AudioSource lobby_audio_souce;
	public AudioSource game_audio_source;
	public AudioSource end_audio_source;


	//public AudioClip lobby_music, main_music, end_music;

	public void Initialize ()
	{
		instance = this;
	}

	void Start()
	{
		Manager_Event.EM.EVT_Game_Over += PlayEndMusic;
		PlayLobbyMusic ();
	}

	public void SpeedUpMusic(float new_pitch, float time)
	{
		iTween.ValueTo (this.gameObject, iTween.Hash ("from", 1, "to", new_pitch, "time", time, "onupdate", "UpdatePitch", "onupdatetarget", this.gameObject));
	}



	public void SetNewPitch(float my_pitch)
	{
		game_audio_source.pitch = my_pitch;
	}

	public void PlayLobbyMusic()
	{
		lobby_audio_souce.volume = 1f;
		game_audio_source.volume = 0f;
		end_audio_source.volume = 0f;
	}

	public void PlayMainMuscic()
	{
		lobby_audio_souce.volume = 0f;
		game_audio_source.volume = 1f;
		end_audio_source.volume = 0f;
	}
	public void PlayEndMusic()
	{
		lobby_audio_souce.volume = 0f;
		game_audio_source.volume = 0f;
		end_audio_source.volume = 1f;
	}

	void OnDisable()
	{
		Manager_Event.EM.EVT_Game_Over -= PlayEndMusic;
	}
}
