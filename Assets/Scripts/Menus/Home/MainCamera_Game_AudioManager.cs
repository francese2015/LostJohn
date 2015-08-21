using UnityEngine;
using System.Collections;

/**
 * This script store the state of music and sound variable.
 * It also enables and disables them in according to new settings.
 */
public class MainCamera_Game_AudioManager : MonoBehaviour {

	private AudioManager audioManager;

	private AudioSource musicSource;
	private AudioSource soundsSource;


	// Use this for initialization
	void Start () {
		audioManager = AudioManager.getInstance ();
		musicSource = GetComponents<AudioSource> () [0];
		soundsSource = GetComponents<AudioSource> () [1];
		checkAudio ();
	}
	
	void Update () {
		checkAudio ();
	}


	private void checkAudio() {
		musicSource.enabled = audioManager.canPlayMusic ();
		soundsSource.enabled = audioManager.canPlaySounds ();
		if (!audioManager.canPlaySounds()) {
			Utility.stopSource(soundsSource);
		}
	}
}
