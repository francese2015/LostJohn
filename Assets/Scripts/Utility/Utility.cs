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
				// Debug.Log("clicked " + hit.collider.gameObject.name);
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
		source.enabled = true;

		if (canPlay && source != null) {
			source.volume = volume;
			if (source.isPlaying) {
				source.Stop();
			}
			if (clip != null) {
				source.clip = clip;
				source.Play();
			} else {
				source.Play();
			}
		}
		return canPlay;
	}


	public static void stopSource(AudioSource source) {
		source.Stop ();
		source.enabled = false;
	}

	/**
	 * return the element's index randomly chosed.
	 * E.g. Let's assume to have 3 elements with creation probability respectively of 20%, 50%, 30%.
	 * If this method returns 0 then the object with 20% of chances has been extracted; 
	 * if it returns 1 then the second element, the 50% one, has been extraxted, else the third one.
	 * If it returns -1 an error occured.
	 */
	public static int randomElementWithProbability(ArrayList probs) {
		if (probs.Count <= 1) {
			return (int) probs[0];
		}

		if (!checkSum (probs, 100)) {
			return -1;
		}
		ArrayList range = new ArrayList ();
		range.Add (0);

		// 60% 20% 15% 5%
		// range -> 0 - 60  -  80  -  95  -  100
		// 			   0+60   60+20  80+15  95+5
		for (int i = 0; i < probs.Count; i++) {
			range.Add((int) range[i] + (int) probs[i]);
		}

		Random rand = new Random ();
		int val = Random.Range (0, 101);

		for (int i = 0; i < range.Count - 1; i++) {
			int left = (int) range [i];
			int right = (int) range [i + 1];

			if (val > left && val < right) {
				return i;
			}
		}
		return -1;
	}

	/**
	 * Controls if the elements' sum is equal to the given number.
	 */
	private static bool checkSum(ArrayList list, int n) {
		int sum = 0;
		for (int i = 0; i < list.Count; i++) {
			sum +=  (int) list[i];
		}
		return sum == n;
	}

}