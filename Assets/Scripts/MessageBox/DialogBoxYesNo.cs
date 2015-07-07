using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogBoxYesNo : MonoBehaviour {

	private GameObject buttonYes;
	private GameObject buttonNo;
	private static List<Observer> observers;

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
				notifyObservers(true);

			} else if(Utility.checkInput(buttonNo)) {
				notifyObservers(false);
			}
		}
	}

	private void notifyObservers(bool state) {
		foreach (Observer o in observers) {
			o.notify(state);
		}
	}

	public void register(Observer o) {
		if (observers == null) {
			observers = new List<Observer>();
		}
		if (o != null) {
			int count = observers.Count;
			observers.Add (o);
		} else {
			Debug.LogError("trying to registrate a null observer");
		}
	}

	public void unregister(Observer o) {
		observers.Remove (o);
	}


	public void setDialogText(string s) {
		dialogTextField.text = s;
	}
}
