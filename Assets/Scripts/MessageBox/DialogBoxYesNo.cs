using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogBoxYesNo : MonoBehaviour {

	private GameObject buttonYes;
	private GameObject buttonNo;
	private static Observer observer;

	public int distance = 1;
	public Text dialogTextField;
	
	// Use this for initialization
	void Start () {
		buttonYes = GameObject.FindGameObjectWithTag ("yes");
		buttonNo = GameObject.FindGameObjectWithTag ("no");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {

			if(Utility.checkInput(buttonYes)) {
				notifyObserver(true);

			} else if(Utility.checkInput(buttonNo)) {
				notifyObserver(false);
			}
		}
	}

	private void notifyObserver(bool state) {
		if (observer != null) {
			observer.notify (state);
		}
		Destroy (gameObject, 0.2f);
	}

	public void register(Observer o) {
		if (o != null) {
			observer = o;
		} else {
			Debug.LogError("trying to registrate a null observer");
		}
	}

	public void unregister(Observer o) {
		observer = null;
	}


	public void setDialogText(string s) {
		dialogTextField.text = s;
	}
	
}
