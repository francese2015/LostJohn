using UnityEngine;
using System.Collections;

public class UseDialogBox : MonoBehaviour, Observer {

	public GameObject dialogBox;

	public string dialogtext;

	// Use this for initialization
	void Start () {
		Instantiate (dialogBox, transform.position, Quaternion.identity);
		dialogBox.GetComponent<DialogBoxYesNo> ().setDialogText(dialogtext);
		dialogBox.GetComponent<DialogBoxYesNo> ().register (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void notify (bool state) {
		Debug.Log ("l'utente ha cliccato " + state);
	}
}
