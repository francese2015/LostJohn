using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	public float volume = 0.1f;

	// Use this for initialization
	void Start () {
		AudioSource audioSource = GetComponent<AudioSource> ();
		Utility.playSoundOnSource (audioSource, null, true, volume);
	}
}
