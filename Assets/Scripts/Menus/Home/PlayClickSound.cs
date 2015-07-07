using UnityEngine;
using System.Collections;

/**
 * This script plays the audioclip into the second audio source 
 * holded by the MainCamera, which is the 'Click' sound.
 */
public class PlayClickSound : MonoBehaviour {

	private static AudioSource source;

	public static void play() {
		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
		source = cam.GetComponents<AudioSource> ()[1];
		if (AudioManager.getInstance ().canPlaySounds ()) {
			source.Play ();
		}
	}
}
