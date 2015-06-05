using UnityEngine;
using System.Collections;

/**
 * This class provides many static methods that can help you during the work ;)
 */
public class Utility : MonoBehaviour {
	
	/**
	 * Check if the clicked input correspond to the one given in input.
	 */
	public static bool checkInput(GameObject target) {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			if (hit.collider.gameObject.name == target.name) {
				return true;
			}
		} 
		return false;
	}

	/**
	 * This method takes in input an audio source object,  a clip to play from 
	 * the source (it can be null) and a boolean indicating if the clip
	 * is a sound or a music clip. In the end there is a volume parameter for 
	 * the given audio source.
	 */
	public static bool playSoundOnSource(AudioSource source, AudioClip clip, bool sound, float volume) {
		bool canPlay;

		if (sound) {
			canPlay = AudioManager.getInstance ().canPlaySounds();
		} else {
			canPlay = AudioManager.getInstance ().canPlayMusic();
		}
		if (canPlay && source != null) {
			source.volume = volume;
			if (source.isPlaying) {
				source.Stop();
			}
			if (clip != null) {
				source.PlayOneShot(clip);
			} else {
				source.Play();
			}
		}
		return canPlay;
	}

}