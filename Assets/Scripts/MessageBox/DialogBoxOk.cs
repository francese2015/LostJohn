using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogBoxOk : MonoBehaviour {

	private GameObject buttonOk;
	public Text dialogTextField;
	
	// Use this for initialization
	void Start () {
		buttonOk = GameObject.FindGameObjectWithTag ("ok");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {

			if(Utility.checkInput(buttonOk)) {
				okAction();
			} 
		}
	}

	private void okAction() {
		Destroy (gameObject, 0.2f);
	}

	public void setDialogText(string s) {
		dialogTextField.text = s;
	}
}
