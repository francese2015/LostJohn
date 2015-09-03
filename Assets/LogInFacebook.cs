using UnityEngine;
using System.Collections;

public class LogInFacebook : MonoBehaviour {

	public GameObject FB;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Utility.checkInput (gameObject)) {
				FB.GetComponent<FbManager> ().fbLogin ();
			}
		}
	}
}
