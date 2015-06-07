using UnityEngine;
using System.Collections;

public class DeathSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource audioSource = GetComponent<AudioSource> ();
		Utility.playSoundOnSource (audioSource, null, true, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
