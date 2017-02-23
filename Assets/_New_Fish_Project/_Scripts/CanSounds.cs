using UnityEngine;
using System.Collections;

public class CanSounds : MonoBehaviour {

	public AudioSource can_audio_source;
	public AudioClip bloop_sound;
	public AudioClip error_sound;

	void Start()
	{
		can_audio_source = GetComponent<AudioSource> ();
	}

	public void PlayBloop(float pitch)
	{
		can_audio_source.pitch = pitch;
		can_audio_source.clip = bloop_sound;
		can_audio_source.Play ();
	}

	public void PlayError()
	{
		can_audio_source.clip = error_sound;
		can_audio_source.Play ();
	}
}
