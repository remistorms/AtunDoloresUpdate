using UnityEngine;
using System.Collections;

public class CanSounds : MonoBehaviour {

	public AudioSource can_audio_source;
	public AudioClip bloop_sound;

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
}
