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

		if (cam.GetComponents<AudioSource> ().Length > 0) {
			source = cam.GetComponents<AudioSource> () [1];
			if (source != null && AudioManager.getInstance ().canPlaySounds ()) {
				source.Play ();
			}
		}
	}
}
