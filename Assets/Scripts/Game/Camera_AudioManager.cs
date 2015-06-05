using UnityEngine;
using System.Collections;

/**
 * This script is applied to the game camera and handles
 * its audio source to play or not the soundtrack.
 */
public class Camera_AudioManager : MonoBehaviour {

	// Update is called once per frame
	void Start () {
		bool music = AudioManager.getInstance ().canPlayMusic ();
		AudioSource source = GetComponent<AudioSource> ();
		source.enabled = music;
	}
}
