using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * This script check if the user has ever logged with facebook. 
 * If he did, the script tries automatically to connect, without need to click on "login".
 */
public class AutoLoginFacebook : MonoBehaviour {
	
	public GameObject FB;

	// Use this for initialization
	void Start () {
		StartCoroutine (login ());
	}

	IEnumerator login() {
		yield return  new WaitForSeconds(1);

		string key = StorageManager.CONNECTED_TO_FACEBOOK;
		
		bool everLogged = StorageManager.loadBoolFromDisk (key);
		
		if (everLogged) {			
			Debug.LogError ("I can connect to FB automatically");
			FB.GetComponent<FbManager> ().fbLogin ();
		} else {
			Debug.LogError ("Never connected");
			
		}
	}

}
