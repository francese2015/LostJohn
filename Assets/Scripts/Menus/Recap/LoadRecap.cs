	using UnityEngine;
using System.Collections;

public class LoadRecap : MonoBehaviour {
	
	public GameObject recap;
	public Transform startPos;
	public GameObject[] toDeactivate;

	public void loadRecap() {
		deactivate ();
		GameObject.Instantiate (recap, startPos.position, Quaternion.identity);
		recap.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	

	private void deactivate() {
		for (int i = 0; i < toDeactivate.Length; i++) {
			toDeactivate[i].gameObject.SetActive(false);
		}
	}


}
