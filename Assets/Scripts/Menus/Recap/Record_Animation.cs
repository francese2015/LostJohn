using UnityEngine;
using System.Collections;

public class Record_Animation : MonoBehaviour {

	public float initialScaleFactor = 1f;
	public float endScaleFactor = 0.3f;
	public float timeWait = 1.5f;


	public static bool canAnimate = false;

	private Vector3 start, end;

	private Vector3 vel = Vector3.zero;

	public AudioClip newRecord;
	private AudioSource source;

	// Use this for initialization
	IEnumerator Start () {
		source = GetComponent<AudioSource> ();
		source.volume = 0.4f;

		transform.localScale = Vector3.zero;

		yield return new WaitForSeconds (timeWait);

		source.Play ();

		Vector3 initialSize = new Vector3 (initialScaleFactor, initialScaleFactor, 0);
		Vector3 finalSize = new Vector3 (endScaleFactor, endScaleFactor, 0);

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
