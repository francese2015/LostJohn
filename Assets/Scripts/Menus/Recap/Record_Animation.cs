using UnityEngine;
using System.Collections;

/**
 * Script used to show thr NEW RECORD! animation in the recap menu when a new best score is reached.
 */
public class Record_Animation : MonoBehaviour {
	// how much the sprite has to be scaled
	public float initialScaleFactor = 1f;
	public float endScaleFactor = 0.3f;
	public float timeWait = 1.5f;

	public static bool canAnimate = false;

	// audio source and audio clip to animate sound
	public AudioClip newRecord;
	private AudioSource source;

	IEnumerator Start () {
		source = GetComponent<AudioSource> ();
		source.volume = 0.4f;

		transform.localScale = Vector3.zero;

		// wait before start the animation
		yield return new WaitForSeconds (timeWait);
		Utility.playSoundOnSource (source, null, true, 0.3f);

		// calculate the initial and final size the object will have to make a zoom effect
		Vector3 initialSize = new Vector3 (initialScaleFactor, initialScaleFactor, 0);
		Vector3 finalSize = new Vector3 (endScaleFactor, endScaleFactor, 0);

		// start animation
		yield return StartCoroutine (ScaleObject (transform, initialSize, finalSize, 0.5f));
	}
		
	IEnumerator ScaleObject (Transform thisTransform, Vector3 startSize, Vector3 endSize, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.localScale = Vector3.Lerp(startSize, endSize, i);
			yield return null; 
		}
	}
	
}
