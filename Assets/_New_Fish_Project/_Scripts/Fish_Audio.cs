using UnityEngine;
using System.Collections;

public class Fish_Audio : MonoBehaviour {

	public AudioSource fish_audio_source;
	public AudioClip[] splash_audio;
	void Start()
	{
		fish_audio_source = GetComponent<AudioSource> ();
	}

	public void PlaySplash()
	{
		Debug.Log ("Playing Splash Audio");
		fish_audio_source.clip = splash_audio [Random.Range (0, splash_audio.Length)];
		fish_audio_source.Play ();
	}
}
