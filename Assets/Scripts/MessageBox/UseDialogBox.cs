using UnityEngine;
using System.Collections;

public class UseDialogBox : MonoBehaviour, Observer {

	public GameObject dialogBox;

	// Use this for initialization
	void Start () {
		Instantiate (dialogBox, transform.position, Quaternion.identity);
		dialogBox.GetComponent<DialogBoxYesNo> ().setDialogText("panel text");
		dialogBox.GetComponent<DialogBoxYesNo> ().register (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void notify (bool state) {
		Debug.Log ("l'utente ha cliccato " + state);
	}
}
