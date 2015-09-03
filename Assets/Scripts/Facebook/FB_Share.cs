using UnityEngine;
using System.Collections;

public class FB_Share : MonoBehaviour {

	private GameObject FacebookObject;

	void Start() {
		FacebookObject = GameObject.Find ("FacebookObject");
		if (FacebookObject == null) {
			Debug.LogError("Cannot share your score because cannot find Facebook Object");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)) {
			if (Utility.checkInput(gameObject)) {
				FacebookObject.GetComponent<FbManager>().share();
			}
		}
	
	}
}
