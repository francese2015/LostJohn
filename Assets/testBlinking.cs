using UnityEngine;
using System.Collections;

public class testBlinking : MonoBehaviour {

	public float sec;
	public float wait;

	// Use this for initialization
	SpriteRenderer r;
	private bool started = false;

	void Start () {
		r = GetComponent<SpriteRenderer> ();
		if (r == null) {
			Debug.LogError("ERROR");
		}



	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			StartCoroutine (blink ());
			started = true;
		}
	}



	private IEnumerator blink() {
		for (;;) {
			r.color = Color.Lerp (Color.red, Color.cyan, sec);
			yield return new WaitForSeconds (wait);
			r.color = Color.Lerp (Color.cyan, Color.red, sec);
			yield return new WaitForSeconds (wait);
		}
	}
}
